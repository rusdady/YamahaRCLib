///************************************************************
///Class implements custom attribute to bind class member
///and "Cmd" XML element from receiver's response
///************************************************************
using System;

namespace YamahaAVLib.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Enum | AttributeTargets.Field)]
    internal class CommandAttribute : Attribute
    {
        string _attributeName;
        string _attributeValue;

        public string Name => _attributeName;
        public string Value => _attributeValue;
        public CommandAttribute(string Name, string Value)
        {
            this._attributeName = Name;
            this._attributeValue = Value;
        }
    }
}
