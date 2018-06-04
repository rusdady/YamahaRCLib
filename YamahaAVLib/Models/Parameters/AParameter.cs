using System.Xml.Linq;

namespace YamahaAVLib.Models.Parameters
{
    internal abstract class AParameter : IParameter
    {
        public XName ParentTag { get; set; }
        public string Func { get; set; }
        public string ID { get; set; }
        public string Value { get; set; }
        public string Func_Ex { get; set; }
        public string Icon_On { get; set; }

        public AParameter(XElement element)
        {
            if (element!=null)
            {
                this.Func = element.Attribute("Func")?.Value;
                this.Func_Ex = element.Attribute("Func_Ex")?.Value;
                this.Icon_On = element.Attribute("Icon_On")?.Value;
                this.Value = element.Value;
                this.ID = element.Attribute("ID")?.Value; 
            }
        }
    }
}
