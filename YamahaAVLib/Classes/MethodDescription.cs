///*****************************************************
///
///*****************************************************
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using YamahaAVLib.ENums;
using YamahaAVLib.Models.Parameters;

namespace YamahaAVLib.Models
{
    internal class MethodDescription
    {
        #region Class members that represent XML description of YNC function/command/method
        /// <summary>
        /// Gets method node name Get/Put
        /// </summary>
        public MethodType Method { get; private set; }
        /// <summary>
        /// Gets type of Put node - 1 or 2
        /// </summary>
        public int PutType { get; private set; } = -1;
        /// <summary>
        /// Gets list of commands
        /// </summary>
        public List<Command> Commands { get; private set; } = new List<Command>();
        /// <summary>
        /// Gets list of acceptable parameters for Put or Get commands
        /// </summary>
        public List<IParameter> Parameters { get; private set; } = new List<IParameter>();
        #endregion

        #region Constructor
        public MethodDescription(XElement method, MethodType methodType)
        {
            this.Method = methodType;
            ParseNode(method, methodType);
        }
        #endregion

        /// <summary>
        /// Parses XML description of YNC function/command/method and initializes class members with parsed values
        /// </summary>
        /// <param name="node">XML description of YNC function/command/method</param>
        /// <param name="methodType">YNC function/command enum flag</param>
        private void ParseNode(XElement node, MethodType methodType = MethodType.NONE)
        {
            List<XElement> childNodes = null;
            if (methodType == MethodType.NONE) { childNodes = node.Elements().ToList(); }
            else if (methodType == MethodType.PUT)
            {
                childNodes = node.Elements().Where(d => d.Name.ToString().StartsWith("Put_")).ToList();
                if(childNodes.Count()>0)
                {
                    this.PutType = int.Parse(Regex.Split(childNodes[0].Name.ToString(), "_")[1]);
                }
            }
            else if (methodType == MethodType.GET) { childNodes = node.Elements("Get").ToList(); }

            foreach (XElement x in childNodes)
            {
                if (x.Name.ToString().Equals("Put_2") || x.Name.ToString().Equals("Get"))
                {
                    //get <Cmd> node
                    if (x.Element("Cmd") != null) this.Commands.Add(new Command(x.Element("Cmd")));

                    //get <Param_1>, <Param_2>, and etc nodes
                    if (x.Elements().Where(d => d.Name.ToString().StartsWith("Param_")).ToList().Count() > 0)
                    {
                        List<XElement> param = x.Elements().Where(d => d.Name.ToString().StartsWith("Param_")).ToList();

                        foreach (XElement p in param)
                        {
                            List<XElement> nval = p.Elements().ToList();

                            foreach (XElement n in nval)
                            {
                                IParameter par = null;

                                switch (n.Name.ToString())
                                {
                                    case "Direct": par = new Direct(n) { ParentTag = p.Name }; break;
                                    case "Indirect": par = new Indirect(n) { ParentTag = p.Name }; break;
                                    case "Range": par = new Range(n) { ParentTag = p.Name }; break;
                                    case "Text": par = new Text(n) { ParentTag = p.Name }; break;
                                }

                                this.Parameters.Add(par);
                            }
                        }
                    } 
                }
                else //<Put_1>
                {
                    this.Commands.Add(new Command(x));
                }

            }
        }

        public IParameter FindParameter(string parameter)
        {
            return Parameters.Find(x => x.ParentTag.ToString().Equals(parameter));
        }
    }
}

/*
<Menu Func="Vol_Lvl" List_Type="Slider" Title_1="Level">
  <Put_2>
    <Cmd Type="Number" ID="P2">Val=Param_1:Exp=Param_2:Unit=Param_3</Cmd>
    <Param_1>
      <Range>-805,165,5</Range>
    </Param_1>
    <Param_2>
      <Direct>1</Direct>
    </Param_2>
    <Param_3>
      <Direct>dB</Direct>
    </Param_3>
  </Put_2>
  <Get>
    <Cmd Type="Number" ID="G1">Volume,Lvl,Val=Param_1:Volume,Lvl,Exp=Param_2:Volume,Lvl,Unit=Param_3</Cmd>
    <Param_1>
      <Range>-805,165,5</Range>
    </Param_1>
    <Param_2>
      <Direct>1</Direct>
    </Param_2>
    <Param_3>
      <Direct>dB</Direct>
    </Param_3>
  </Get>
</Menu>

<Menu Func="Status" Title_1="Device">
  <Get>
    <Cmd ID="G2">Feature_Availability=Param_1</Cmd>
    <Param_1>
      <Direct Func="Status_Ready">Ready</Direct>
      <Direct Func="Status_Not_Ready">Not Ready</Direct>
    </Param_1>
  </Get>
</Menu>


<Menu Func="Event" Title_1="Event">
  <Put_1 Func="Event_On" ID="P1">On</Put_1>
  <Put_1 Func="Event_Off" ID="P1">Off</Put_1>
  <Get>
    <Cmd ID="G1">Param_1</Cmd>
    <Param_1>
      <Direct Func="Event_On">On</Direct>
      <Direct Func="Event_Off">Off</Direct>
    </Param_1>
  </Get>
</Menu>
     */
