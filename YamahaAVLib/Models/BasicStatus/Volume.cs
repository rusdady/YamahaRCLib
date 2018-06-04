using YamahaAVLib.YNC;

namespace YamahaAVLib.Models.BasicStatus
{
    public class Volume
    {
        [YNCTag("Lvl")]
        public Level VolumeLevel { get; set; } = new Level();

        [YNCTag("Mute")]
        public bool Mute { get; set; }
    }
}
