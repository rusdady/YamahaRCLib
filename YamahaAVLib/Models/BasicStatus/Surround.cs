using YamahaAVLib.YNC;

namespace YamahaAVLib.Models.BasicStatus
{
    public class Surround
    {
        [YNCTag("Current")]
        public CurrentSurroundProgram CurrentSurroundProgram { get; set; } = new CurrentSurroundProgram();

        [YNCTag("_3D_Cinema_DSP")]
        public bool Cinema3DDSP { get; set; }

    }
}
