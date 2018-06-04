using YamahaAVLib.YNC;

namespace YamahaAVLib.Models.BasicStatus
{
    public class PowerControl
    {
        [YNCTag("Power")]
        public bool Power { get; set; }

        [YNCTag("Sleep")]
        public bool Sleep { get; set; }
    }
}
