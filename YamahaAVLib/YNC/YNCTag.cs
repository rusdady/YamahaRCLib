using System;

namespace YamahaAVLib.YNC
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property)]
    public class YNCTag : Attribute
    {
        private string tag_name;
        public string Name => tag_name;
        public YNCTag(string Name)
        {
            tag_name = Name;
        }
    }
}
