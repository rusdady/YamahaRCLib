using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using YamahaAVLib.Classes;
using YamahaAVLib.ENums;

namespace YamahaAVLib.Models
{
    public class SliderRange
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int Step { get; set; }

        public SliderRange(FunctionType funcType)
        {
            XElement vol = (new Communication()).GetCommandXMLDescription(funcType);
            XElement xRange = vol.Descendants("Range").FirstOrDefault();
            string[] vals = xRange.Value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            this.MinValue = int.Parse(vals[0]);
            this.MaxValue = int.Parse(vals[1]);
            this.Step = int.Parse(vals[2]);
        }
    }
}
