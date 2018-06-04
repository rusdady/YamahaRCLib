using YamahaAVLib.YNC;

namespace YamahaAVLib.Models.BasicStatus
{
    public class HDMI
    {
        [YNCTag("Standby_Through_Info")]
        public bool HDMIThrough { get; set; }

        [YNCTag("OUT_1")]
        public bool Output { get; set; }
    }
}
