///************************************************************
///Class implements custom attribute to bind class member
///and "Device" attribute of XML element from receiver's response
///************************************************************
using System;

namespace YamahaAVLib.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class DeviceAttribute : ParentFuncAttribute
    {
        public DeviceAttribute(string Value) : base(Value)
        {
        }

        public DeviceAttribute(string Name, string Value) : base(Name, Value)
        {
        }
    }
}
