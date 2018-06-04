using YamahaAVLib.YNC;

namespace YamahaAVLib.Models.BasicStatus
{
    public class Level
    {
        [YNCTag("Val")]
        public int Value { get; set; }

        [YNCTag("Exp")]
        public int Expansion { get; set; }

        [YNCTag("Unit")]
        public string Unit { get; set; }
    }
}
