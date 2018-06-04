using YamahaAVLib.YNC;

namespace YamahaAVLib.Models.BasicStatus
{
    public class InputIcon
    {
        [YNCTag("On")]
        public string On { get; set; }

        [YNCTag("Off")]
        public string Off { get; set; }
    }
}

