using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using YamahaAVLib.Attributes;
using YamahaAVLib.Classes;
using YamahaAVLib.Config;
using YamahaAVLib.ENums;
using YamahaAVLib.Extensions;
using YamahaAVLib.Models;
using YamahaAVLib.Models.BasicStatus;
using YamahaAVLib.Models.Parameters;

namespace YamahaAVLib.YNC
{
    public class YNCFunctionBuilder
    {
        private string _acceptableParameters = string.Empty;
        private string _hostNameOrAddress = string.Empty;

        public XElement SelectionList { get; private set; } = null;
        public XElement UnitResponse { get; private set; } = null;


        public YNCFunctionBuilder(string hostNameorAddress) 
        {
            this._hostNameOrAddress = hostNameorAddress;
        }

        public YNCFunctionBuilder() { }

        /// <summary>
        /// Method sends request to receiver to change status of a function.
        /// </summary>
        /// <param name="funcType">FunctionType enum value</param>
        /// <param name="value">Value to be sent to receiver</param>
        /// <returns>bool</returns>
        public bool SetStatusOf(FunctionType funcType, object value)
        {
            object funcValue = value;
            string funcPath = "";
            bool result = false;
            XElement cmdX = GetCommandXMLDescription(funcType);
            MethodDescription mdp = new MethodDescription(cmdX, MethodType.PUT);

            if (VerifyInputParameter(mdp, (string)value))
            {
                if (mdp.PutType == 1) //if <Put_1>
                {
                    //<Put_1> nodes value usually represents value that should be sent.
                    //Usually there can be many <Put_1> nodes for particular command,
                    //but they all have the same ID. So let's take funcPath <Cmd_List> node by ID.
                    if (mdp.Commands.Count() > 0)
                    {
                        Command cmd = mdp.Commands[0];
                        funcPath = YNCDefineFuncSelector.SelectCmdFunctionPath(funcType, cmd.ID);
                    }
                }
                else if (mdp.PutType == 2) //if <Put_2>
                {
                    if (mdp.Commands.Count() > 0)
                    {
                        Command cmd = mdp.Commands[0];

                        if (cmd.Values.Count() > 1)
                        {
                            funcPath = YNCDefineFuncSelector.SelectCmdFunctionPath(funcType, cmd.ID);
                            List<XElement> elements = new List<XElement>();

                            foreach (string s in cmd.Values)
                            {
                                string tag = s.EqualSplit(0);
                                string param_n = s.EqualSplit(1);
                                XElement element = new XElement(tag);
                                IParameter parameter = mdp.FindParameter(param_n);
                                element.Value = (parameter.GetType() == typeof(Range) ? (string)value : parameter.Value);
                                elements.Add(element);
                            }
                            //funcValue is an object type, we set List<XElement> list to it
                            funcValue = elements;

                        }
                        else
                        {
                            //if <Cmd> node value contains only Param_1: <Cmd ID="P3">Param_1</Cmd>
                            //then refer command in <Cmd_List> node by ID
                            if (cmd.Values[0].Equals(Atomics.Param))
                            {
                                funcPath = YNCDefineFuncSelector.SelectCmdFunctionPath(funcType, cmd.ID);
                            }
                            else
                            {

                            }
                        }
                    }
                }

                try
                {
                    XElement resp = (new Communication(this._hostNameOrAddress)).SendYNCCommand(MethodType.PUT, funcPath, funcValue);
                    if (resp.Attribute("RC")?.Value == "0") { result = true; }
                }
                catch {}
            }
            else
            {
                throw new Exception("Parameter is not valid. Acceptable parameters: " + _acceptableParameters);
            }

            return result;
        }

        /// <summary>
        /// Method sends XML request to receiver about function status. Returned XML response is parsed and its parameter and value 
        /// returned as list of OutputParameter objects.
        /// </summary>
        /// <param name="funcType">FunctionType enum value</param>
        /// <returns>List of OutputParameter objects</returns>
        public List<Output> GetStatusOf(FunctionType funcType)
        {
            List<Output> output = new List<Output>();

            //Find XML menu node that contains definitions for function
            XElement cmdX = GetCommandXMLDescription(funcType);

            //Find and parse GET definitions for the function
            MethodDescription mdg = new MethodDescription(cmdX, MethodType.GET);

            //<Get> node may contain only one <Cmd> node which describes function and what parameters it returns.
            //<Get> node also may contain description of returning values in <Param_1>, <Param_2>, <Param_n> nodes.
            //Usually <Get> functions do not have parameters to pass with request. They use "GetParam" keyword as
            //a value for XML request.
            if (mdg.Commands.Count() > 0)
            {
                Command cmd = mdg.Commands[0];

                //<Cmd> node has ID atribute (like ID="G1") which value (G1) referes to request (Get) command in 
                //<Cmd_List><Define ID="G1"> node. So we'll take function path from <Cmd_List> by ID.
                //Value of Cmd node just describes from what nodes in response we should get requested value.
                string path = YNCDefineFuncSelector.SelectCmdFunctionPath(funcType, cmd.ID);

                //path contains comma delimited string like this "Main_Zone,Basic_Status". For valid request we should
                //build XML request out of that path - <Main_Zone><Basic_Status>GetParam</Basic_Status></Main_Zone>
                //and send it over to receiver.
                this.UnitResponse = (new Communication(this._hostNameOrAddress)).SendYNCCommand(MethodType.GET, path);


                //Command of <Get> node may look like this: <Cmd Type="Number" ID="P2">Val=Param_1:Exp=Param_2:Unit=Param_3</Cmd>
                //It contains descriptions of three nodes <Val>, <Exp>, <Unit> :"Val=Param_1", "Exp=Param_2", "Unit=Param_3".
                //"Param_" values just refer description of returning data and can be found in <Param_1>, <Param_2>, <Param_3> nodes
                //next to <Cmd> node.
                // <Get>
                //    <Cmd Type="Number" ID="G1">Volume,Lvl,Val=Param_1:Volume,Lvl,Exp=Param_2:Volume,Lvl,Unit=Param_3</Cmd>
                //    <Param_1>
                //        <Range>-805,165,5</Range>
                //    </Param_1>
                //    <Param_2>
                //        <Direct>1</Direct>
                //    </Param_2>
                //    <Param_3>
                //        <Direct>dB</Direct>
                //    </Param_3>
                //</Get>
                foreach (string scmd in cmd.Values)
                {
                    XElement outPar = this.UnitResponse;
                    string[] nodes = scmd.Split(new string[] { "=", "," }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string n in nodes)
                    {
                        if(!n.StartsWith("Param", StringComparison.CurrentCultureIgnoreCase))
                            outPar = outPar.Descendants(n).ToList()[0];
                    }

                    if (outPar != null) output.Add(new Output() { ParameterName = outPar.Name.ToString(), Value = outPar.Value });
                }

                this.SelectionList = GetSelectList(cmdX, mdg, funcType);
            }

            
            return output;
        }

        /// <summary>
        /// If command Get contains paramater of Indirect type, then it means we have to
        /// get selection list from receiver.
        /// </summary>
        /// <param name="mdg">MethodDescription</param>
        /// <param name="funcType">FunctionType</param>
        /// <returns>Xelement selection list</returns>
        private XElement GetSelectList(XElement cmdX, MethodDescription mdg, FunctionType funcType)
        {
            XElement result = null;
            if (mdg.Parameters.Count() > 0)
            {
                if (mdg.Parameters.Where(x => x.GetType() == typeof(Indirect)).Count() > 0)
                {
                    string id = mdg.Parameters.Where(x => x.GetType() == typeof(Indirect)).FirstOrDefault().ID;
                    string path = YNCDefineFuncSelector.SelectCmdFunctionPath(funcType, id);
                    result = (new Communication(this._hostNameOrAddress)).SendYNCCommand(MethodType.GET, path);//.Descendants().Where(x => x.Name.ToString().StartsWith("Item_")).ToList();
                }
                else
                {
                    result = cmdX.Descendants("Get").Descendants().Where(x => x.Name.ToString().StartsWith("Param_")).FirstOrDefault();
                }
            }
            return result;
        }

        public XElement GetCommandXMLDescription(FunctionType funcType) 
        {
            //if (this._unitDescription == null && unitDescription == null) throw new Exception("Receiver response is empty.");
            //unitDescription = this._unitDescription ?? unitDescription;
            if (Atomics.UnitDescription == null) throw new Exception("Receiver response is empty.");

            XElement element = null;
            string attrName;
            string attrValue;

            FieldInfo fieldInfo = funcType.GetType().GetRuntimeField(funcType.ToString());

            List<CustomAttributeData> dat = fieldInfo.CustomAttributes.ToList();

            foreach (CustomAttributeData ca in dat)
            {
                if (ca.AttributeType == typeof(Attributes.DeviceAttribute))
                {
                    attrName = funcType.GetAttribute<Attributes.DeviceAttribute>().Name;
                    attrValue = funcType.GetAttribute<Attributes.DeviceAttribute>().Value;
                    element = GetChildNode(attrName, attrValue, element ?? Atomics.UnitDescription);
                }
                else if (ca.AttributeType == typeof(ParentFuncAttribute))
                {
                    attrName = funcType.GetAttribute<ParentFuncAttribute>().Name;
                    attrValue = funcType.GetAttribute<ParentFuncAttribute>().Value;
                    element = GetChildNode(attrName, attrValue, element ?? Atomics.UnitDescription);
                }
                else if (ca.AttributeType == typeof(FuncAttribute))
                {
                    attrName = funcType.GetAttribute<FuncAttribute>().Name;
                    attrValue = funcType.GetAttribute<FuncAttribute>().Value;
                    element = GetChildNode(attrName, attrValue, element ?? Atomics.UnitDescription);
                }
                else if (ca.AttributeType == typeof(FuncExAttribute))
                {
                    attrName = funcType.GetAttribute<FuncExAttribute>().Name;
                    attrValue = funcType.GetAttribute<FuncExAttribute>().Value;
                    element = GetChildNode(attrName, attrValue, element ?? Atomics.UnitDescription);
                }
            }

            return element;
        }

        private XElement GetChildNode(string attrName, string attrValue, XElement element)
        {
            XElement ex = (new YQuery(element)).GetNode("Menu", attrName, attrValue).Node;
            return ex ?? element;
        }

        private bool VerifyInputParameter(MethodDescription mdp, string parameter)
        {
            bool result = false;
            string parameters = string.Empty;
            List<Command> cmds = mdp.Commands;
            this._acceptableParameters = string.Empty;

            if (mdp.PutType == 1)
            {
                foreach (Command cmd in cmds)
                {
                    result = VerifyParameter<string>(cmd.Values, parameter);
                    if (result == true) break;
                }
            }
            else if(mdp.PutType==2)
            {
                result = VerifyParameter<IParameter>(mdp.Parameters, parameter);
            }

            return result;
        }

        /// <summary>
        /// Verifies if input value for the function is valid one. the logic is based on XML unit description 
        /// received from receiver. Nodes type of Indirect do not get validated - they require receiving 
        /// list of possible values from receiver.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="parameters">List of valid values</param>
        /// <param name="parameter">Value to be sent</param>
        /// <returns></returns>
        private bool VerifyParameter<T>(List<T> parameters, string parameter)
        {
            bool result = false;

            foreach (T par in parameters)
            {
                if (par.GetType() == typeof(Range))
                {
                    int intValue = int.Parse(parameter);
                    if (intValue<=(par as Range).MaxValue && intValue>= (par as Range).MinValue)
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        _acceptableParameters = string.Format("Parameter ({0}) is out of acceptable range:{1} - {2}", parameter, (par as Range).MinValue.ToString(), (par as Range).MaxValue.ToString());
                    }
                }
                else if (par.GetType() == typeof(Text))
                {
                    if (parameter.Length <= (par as Text).MaxValue && parameter.Length >= (par as Text).MinValue)
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        _acceptableParameters = string.Format("Parameter ({0}) is out of acceptable range:{1} - {2}", parameter, (par as Text).MinValue.ToString(), (par as Text).MaxValue.ToString());
                    }
                }
                else if (par.GetType() == typeof(Indirect))
                {
                    result = true;
                }
                else
                {
                    string value = (string)(par.HasProperty<T>("Value") ? par.GetValue<T>("Value") : par.ToString());

                    _acceptableParameters += value + ",";

                    if (value.Equals(parameter, StringComparison.CurrentCulture))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Returns input list
        /// </summary>
        /// <returns></returns>
        public XElement GetReceiverInputList()
        {
            return GetReceiverList(FunctionType.SubunitInput, "G2");
        }

        /// <summary>
        /// Returns scene list
        /// </summary>
        /// <returns></returns>
        public XElement GetReceiverSceneList()
        {
            return GetReceiverList(FunctionType.SubunitScene, "G3");
        }

        public XElement GetTunerPresetList()
        {
            return GetReceiverList(FunctionType.TunerPlayControlPreset, "G3");
        }

        public List<XElement> GetSurroundProgramList()
        {
            //Find XML menu node that contains definitions for function
            XElement cmdX = GetCommandXMLDescription(FunctionType.SubunitSurroundProgram);
            return cmdX.Element("Get").Descendants("Direct").ToList();
        }
        public BasicStatus GetBasicStatus()
        {
            BasicStatus oBasicStatus = new BasicStatus();
            XElement xBasicStatus = GetReceiverList(FunctionType.SubunitInput, "G1");
            if(xBasicStatus!=null) oBasicStatus = (new BasicStatus(xBasicStatus)).Parse();
            return oBasicStatus;
        }
        private XElement GetReceiverList(FunctionType funcType, string id)
        {
            string path = YNCDefineFuncSelector.SelectCmdFunctionPath(funcType, id);
            return (new Communication(this._hostNameOrAddress)).SendYNCCommand(MethodType.GET, path);
        }

        /// <summary>
        /// Get list of receiver's devices like Tuner, USB, AirPlay, and e.t.c and its status.
        /// </summary>
        /// <returns>List of status</returns>
        public List<DeviceStatus> CheckDeviceStatus()
        {
            List<DeviceStatus> result = new List<DeviceStatus>();

            //get list of nodes having Func Attribute = Source_Device
            List<XElement> devices = Atomics.UnitDescription.Elements().Where(x => x.Attribute("Func") != null && x.Attribute("Func").Value == "Source_Device").ToList();

            //iterate through devices
            foreach(XElement device in devices)
            {
                //get definition of the status command
                XElement statusCommand = device.Elements("Menu").Where(x => x.Attribute("Func") != null && x.Attribute("Func").Value == "Status").FirstOrDefault();
                //Find and parse GET definitions for the function
                MethodDescription mdg = new MethodDescription(statusCommand, MethodType.GET);
                //get list of available commands for the device
                XElement cmd_list = device.Elements("Cmd_List").FirstOrDefault();
                //find device status function path
                string path = cmd_list.Elements("Define").Where(x => x.Attribute("ID")!=null && x.Attribute("ID").Value== mdg.Commands[0].ID).FirstOrDefault().Value;
                //request status of the device from receiver
                XElement resp = (new Communication(this._hostNameOrAddress)).SendYNCCommand(MethodType.GET, path);
                //get description of status path from command description
                string featurePath = mdg.Commands[0].Values[0].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[0];
                //get device name
                string name = device.Attribute("YNC_Tag").Value;
                //get device status
                string status = resp.Descendants(featurePath).FirstOrDefault().Value;
                //add device status to collection
                result.Add(new DeviceStatus(name, status));
            }

            return result;
        }


        public string MakeIconUri(string icon)
        {
            return string.Format("http://{0}{1}", this._hostNameOrAddress, icon);
        }

    }
}
