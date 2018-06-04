using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using YamahaAVLib.Classes;
using YamahaAVLib.ENums;
using YamahaAVLib.YNC;

namespace YamahaAVLib.Models.PlayList
{
    public class PlayListInfo : TypedXMLResponseParser
    {
        [YNCTag("Menu_Status")]
        public string Status { get; set; }

        [YNCTag("Menu_Layer")]
        public int Layer { get; set; }

        [YNCTag("Menu_Name")]
        public string Name { get; set; }

        [YNCTag("Current_List")]
        public List<PlayListItem> CurrentList { get; set; } = new List<PlayListItem>();

        [YNCTag("Cursor_Position")]
        public PlayListPosition Position { get; set; } = new PlayListPosition();

        private XElement _xdocument = null;
        public PlayListInfo(XElement xdocument)
        {
            _xdocument = xdocument;
        }

        /// <summary>
        /// Empty constructor required for generic operations
        /// </summary>
        public PlayListInfo()
        {
        }
        public PlayListInfo Parse()
        {
            if (_xdocument == null) throw new Exception("XDocument is empty");

            Type type = typeof(PlayListInfo);
            PlayListInfo plInfo = (PlayListInfo)base.Parse(type.GetProperties(), _xdocument);

            for(int i=0; i<plInfo.CurrentList.Count(); i++)
            {
                plInfo.CurrentList[i].Parameter = string.Format("Line_{0}", (i + 1).ToString());
                var itemType = plInfo.CurrentList[i].Attribute.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0];
                plInfo.CurrentList[i].ItemType = (PlayListItemType)Enum.Parse(typeof(PlayListItemType), itemType);
            }

            return plInfo;
        }

    }
}
