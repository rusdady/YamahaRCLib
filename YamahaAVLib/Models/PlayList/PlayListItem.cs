using System;
using YamahaAVLib.ENums;
using YamahaAVLib.YNC;

namespace YamahaAVLib.Models.PlayList
{
    public class PlayListItem
    {
        [YNCTag("Txt")]
        public string Text { get; set; }

        [YNCTag("Attribute")]
        public string Attribute { get; set; }

        public string  Parameter { get; set; }

        public PlayListItemType ItemType { get; set; }

}
}
