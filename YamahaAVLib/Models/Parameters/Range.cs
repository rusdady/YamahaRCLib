using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace YamahaAVLib.Models.Parameters
{
    internal class Range : AParameter
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int Expansion { get; set; }
        public string LineNumber { get; set; }


        public Range(XElement element) : base(element)
        {
            if (element != null)
            {
                string[] r = Regex.Split(this.Value, ",");

                this.MinValue = int.Parse(r[0]);
                this.MaxValue = int.Parse(r[1]);
                this.Expansion = int.Parse(r[2]);
                if (r.Length > 3) this.LineNumber = r[3];
            }
        }

    }
}
