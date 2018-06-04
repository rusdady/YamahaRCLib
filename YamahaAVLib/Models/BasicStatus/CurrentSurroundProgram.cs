using YamahaAVLib.YNC;

namespace YamahaAVLib.Models.BasicStatus
{
    public class CurrentSurroundProgram
    {
        [YNCTag("Enhancer")]
        public bool Enhancer { get; set; }

        [YNCTag("Straight")]
        public bool Straight { get; set; }

        [YNCTag("Sound_Program")]
        public string  SoundProgram { get; set; }

    }
}
