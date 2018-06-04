///************************************************************
///Class implements custom attribute to bind class member
///and "Func" attribute of XML element from receiver's response
///************************************************************
using System;

namespace YamahaAVLib.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class FuncAttribute : Attribute
    {
        string _attributeValue;

        public string Name => "Func";
        public string Value => _attributeValue;
        public FuncAttribute(string Value)
        {
            this._attributeValue = Value;
        }
    }
}
