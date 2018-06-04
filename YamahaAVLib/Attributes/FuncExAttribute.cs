///************************************************************
///Class implements custom attribute to bind class member
///and "Func_Ex" attribute of XML element from receiver's response
///************************************************************
using System;

namespace YamahaAVLib.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class FuncExAttribute : FuncAttribute
    {
        public new string Name => "Func_Ex";
        public FuncExAttribute(string Value):base(Value)
        {
        }
    }
}
