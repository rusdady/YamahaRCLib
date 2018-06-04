///****************************************************
///Class implements method to parse list of available
///receiver's inputs
///****************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using YamahaAVLib.Models.BasicStatus;

namespace YamahaAVLib.Classes
{
    public class InputList : TypedXMLResponseParser
    {

        public List<InputInfo> Parse(XElement xdocument)
        {
            List<InputInfo> list = new List<InputInfo>();

            List<XElement> inputs = xdocument.Descendants().Where(x => x.Name.ToString().StartsWith("Item_")).ToList();
            foreach (XElement e in inputs)
            {
                Type type = typeof(InputInfo);
                InputInfo input = (InputInfo)Parse(type.GetProperties(), e);
                list.Add(input);
            }

            return list;
        }

    }
}
