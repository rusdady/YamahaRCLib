///************************************************************
///Class implements custom attribute to bind class member
///and "Func" attribute of a parent XML element from receiver's response
///************************************************************
using System;

namespace YamahaAVLib.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class ParentFuncAttribute : Attribute
    {
        string _attributeValue;
        string _attributeName = "Func";
        public string Name => _attributeName;
        public string Value => _attributeValue;
        public ParentFuncAttribute(string Value)
        {
            this._attributeValue = Value;
        }

        public ParentFuncAttribute(string Name, string Value)
        {
            this._attributeName = Name;
            this._attributeValue = Value;
        }
    }
}
