using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace YamahaAVLib.Models.Parameters
{
    internal class Text : Range
    {
        public string Encoding { get; set; }

        public Text(XElement element) : base(null)
        {
            if (element != null)
            {
                string[] r = Regex.Split(element.Value, ",");

                this.MinValue = int.Parse(r[0]);
                this.MaxValue = int.Parse(r[1]);
                this.Encoding = r[2];
            }
        }
    }
}
