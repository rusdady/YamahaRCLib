using YamahaAVLib.YNC;

namespace YamahaAVLib.Models.BasicStatus
{
    public class SoundVideo
    {
        [YNCTag("Tone")]
        public Tone Tone { get; set; } = new Tone();

        [YNCTag("Mode")]
        public bool DirectMode { get; set; }

        [YNCTag("Adaptive_DRC")]
        public bool AdaptiveDRC { get; set; }

        [YNCTag("HDMI")]
        public HDMI HDMI { get; set; } = new HDMI();

    }
}
