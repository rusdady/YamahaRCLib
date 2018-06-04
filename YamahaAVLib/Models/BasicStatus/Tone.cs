using YamahaAVLib.YNC;

namespace YamahaAVLib.Models.BasicStatus
{
    public class Tone
    {
        [YNCTag("Bass")]
        public Level Bass { get; set; } = new Level();

        [YNCTag("Treble")]
        public Level Treble { get; set; } = new Level();
    }
}

