///************************************************************
///Class provides functionality to get particular XML command 
///description in XML format from receiver response.
///************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using YamahaAVLib.Attributes;
using YamahaAVLib.ENums;
using YamahaAVLib.Extensions;
using YamahaAVLib.YNC;

namespace YamahaAVLib.Classes
{
    /// <summary>
    /// Class provides functionality to get particular command xml description from receiver response.
    /// </summary>
    public class CommandNode
    {
        #region Declarations
        private XElement _unitResponse; 
        #endregion


        #region Constructor
        public CommandNode(XElement unitResponse)
        {
            this._unitResponse = unitResponse;
        }

        public CommandNode() { }
        #endregion

        /// <summary>
        /// Parses XML passed with unitResponse parameter and returns XML node which contains
        /// YNC function/command structure
        /// </summary>
        /// <param name="funcType">YNC function/command enum flag</param>
        /// <param name="unitResponse">Response from receiver as XElement type object</param>
        /// <returns>XML node which contains YNC function/command structure</returns>
        public XElement GetCommandXMLDescription(FunctionType funcType, XElement unitResponse = null)
        {
            if (this._unitResponse == null && unitResponse == null) throw new Exception("Receiver response is empty.");

            unitResponse = this._unitResponse ?? unitResponse;

            XElement element = null;
            string attrName;
            string attrValue;

            FieldInfo fieldInfo = funcType.GetType().GetRuntimeField(funcType.ToString());

            List<CustomAttributeData> dat = fieldInfo.CustomAttributes.ToList();
            
            foreach(CustomAttributeData ca in dat)
            {
                if(ca.AttributeType==typeof(DeviceAttribute))
                {
                    attrName = funcType.GetAttribute<DeviceAttribute>().Name;
                    attrValue = funcType.GetAttribute<DeviceAttribute>().Value;
                    element = GetChildNode(attrName, attrValue, element ?? unitResponse);
                }
                else if (ca.AttributeType == typeof(ParentFuncAttribute))
                {
                    attrName = funcType.GetAttribute<ParentFuncAttribute>().Name;
                    attrValue = funcType.GetAttribute<ParentFuncAttribute>().Value;
                    element = GetChildNode(attrName, attrValue, element ?? unitResponse);
                }
                else if (ca.AttributeType == typeof(FuncAttribute))
                {
                    attrName = funcType.GetAttribute<FuncAttribute>().Name;
                    attrValue = funcType.GetAttribute<FuncAttribute>().Value;
                    element = GetChildNode(attrName, attrValue, element ?? unitResponse);
                }
                else if (ca.AttributeType == typeof(FuncExAttribute))
                {
                    attrName = funcType.GetAttribute<FuncExAttribute>().Name;
                    attrValue = funcType.GetAttribute<FuncExAttribute>().Value;
                    element = GetChildNode(attrName,attrValue, element ?? unitResponse);
                }
            }

            return element;
        }

        /// <summary>
        /// Parses XML element and returns XML "Menu" node having particular attribute with particular value.
        /// </summary>
        /// <param name="attrName">Attribute name</param>
        /// <param name="attrValue">Attribute value</param>
        /// <param name="element">XML document need to be parsed</param>
        /// <returns>XML "Menu" node having particular attribute with particular value</returns>
        private XElement GetChildNode(string attrName, string attrValue, XElement element)
        {
            XElement ex = (new YQuery(element)).GetNode("Menu", attrName, attrValue).Node;
            return ex ?? element;
        }
    }

}

/*
 Put command is request to change state. ID shows what command we should use from command list <Cmd_List>.
 In this case it would be a command with ID=P3: <Define ID="P3">Main_Zone,Volume,Mute</Define>.
 values in <Put_1> is what we should pass to receiver. 
<Menu Func="Vol_Mute" Title_1="Mute">
  <Put_1 Func="Vol_Mute_On" ID="P3">On</Put_1>
  <Put_1 Func="Vol_Mute_Off" ID="P3">Off</Put_1>
  <Get>

  Cmd contains partial path that contained in G1 command: Main_Zone,Basic_Status
  So we have to execute command with ID=G1 Basic Status, and then take state value from response
  with path Main_Zone,Basic_Status,Volume,Mute. Param_1 contains values which we should expect in response.
    <Cmd ID="G1">Volume,Mute=Param_1</Cmd>
    <Param_1>
      <Direct Func="Vol_Mute_On">On</Direct>
      <Direct Func="Vol_Mute_Off">Off</Direct>
    </Param_1>
  </Get>
</Menu>


    <Cmd_List>
      <Define ID="P1">Main_Zone,Power_Control,Power</Define>
      <Define ID="P2">Main_Zone,Volume,Lvl</Define>
   ===<Define ID="P3">Main_Zone,Volume,Mute</Define>
      <Define ID="P4">Main_Zone,Input,Input_Sel</Define>
      <Define ID="P5">Main_Zone,Config,Name,Zone</Define>
      <Define ID="P6">Main_Zone,Scene,Scene_Sel</Define>
      <Define ID="P7">Main_Zone,Sound_Video,Tone,Bass</Define>
      <Define ID="P8">Main_Zone,Sound_Video,Tone,Treble</Define>
      <Define ID="P9">Main_Zone,Surround,Program_Sel,Current,Sound_Program</Define>
      <Define ID="P10">Main_Zone,Surround,Program_Sel,Current,Straight</Define>
      <Define ID="P11">Main_Zone,Surround,Program_Sel,Current,Enhancer</Define>
      <Define ID="P12">Main_Zone,Sound_Video,Adaptive_DRC</Define>
      <Define ID="P13">Main_Zone,Surround,_3D_Cinema_DSP</Define>
      <Define ID="P14">Main_Zone,Sound_Video,Dialogue_Adjust,Dialogue_Lift</Define>
      <Define ID="P15">System,Sound_Video,HDMI,Video,Preset_Sel,Current</Define>
      <Define ID="P17">Main_Zone,Sound_Video,Direct,Mode</Define>
      <Define ID="P18">Main_Zone,List_Control,Cursor</Define>
      <Define ID="P19">Main_Zone,List_Control,Menu_Control</Define>
      <Define ID="P23">Main_Zone,Power_Control,Sleep</Define>
      <Define ID="P24">Main_Zone,Play_Control,Playback</Define>
  ====<Define ID="G1">Main_Zone,Basic_Status</Define>
      <Define ID="G2">Main_Zone,Input,Input_Sel_Item</Define>
      <Define ID="G3">Main_Zone,Config</Define>
      <Define ID="G4">Main_Zone,Scene,Scene_Sel_Item</Define>
    </Cmd_List>
     */
