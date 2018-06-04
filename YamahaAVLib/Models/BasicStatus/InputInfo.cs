using YamahaAVLib.YNC;

namespace YamahaAVLib.Models.BasicStatus
{
    public class InputInfo : IInput
    {
        [YNCTag("Param")]
        public string Parameter { get; set; }

        [YNCTag("RW")]
        public string ReadWrite { get; set; }

        [YNCTag("Title")]
        public string Title { get; set; }

        [YNCTag("Icon")]
        public InputIcon Icon { get; set; } = new InputIcon();

        [YNCTag("Src_Name")]
        public string SourceName { get; set; }

        [YNCTag("Src_Number")]
        public int SourceNumber { get; set; }

    }
}
