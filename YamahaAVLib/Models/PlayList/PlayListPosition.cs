using YamahaAVLib.YNC;

namespace YamahaAVLib.Models.PlayList
{
    public class PlayListPosition
    {
        [YNCTag("Current_Line")]
        public int CurrentLine { get; set; }

        [YNCTag("Max_Line")]
        public int MaxLine { get; set; }

    }
}
