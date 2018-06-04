using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using YamahaAVLib.ENums;
using YamahaAVLib.Extensions;

namespace YamahaAVLib.YNC
{
    internal class YNCCommand
    {
        #region Declarations

        #endregion


        #region YNC command builders

        /// <summary>
        /// Creates YNC XML formatted request
        /// </summary>
        /// <param name="commandType">PUT,GET, or NONE</param>
        /// <param name="yncRequestPath">List of YNC tags separated with comma: Main_Zone,Power_Control,Power</param>
        /// <param name="param">Optinal parameter. By default set to "GetParam" according to YNC specifications.</param>
        /// <returns></returns>
        public static string CreateCommand(MethodType commandType, string yncRequestPath = null, object param = null)
        {
            string result = "";

            if (commandType != MethodType.NONE)
            {
                //Add YAMAHA_AV element
                XElement yamahaNode = new XElement("YAMAHA_AV", new XAttribute("cmd", commandType.ToString()));
                XElement yncRequest = BuildYNCXElements(yncRequestPath, param);
                yamahaNode.Add(yncRequest);
                result = yamahaNode.ToXMLString();
            }
            else
            {
                XElement empty = new XElement("empty");
                result = empty.ToXMLString().Replace("\r\n<empty />", "");
            }

            return Regex.Replace(result, @"\s*(<[^>]+>)\s*", "$1", RegexOptions.Singleline);
        }

        /// <summary>
        /// Method builds YNC xml request from comma delimited string like
        /// Main_Zone,Input,Input_Sel_Item to XML formatted string like 
        /// &lt;Main_Zone&gt;&lt;Input&gt;&lt;Input_Sel_Item&gt;GetParam&lt;/Input_Sel_Item&gt;&lt;/Input&gt;&lt;/Main_Zone&gt;.
        /// </summary>
        /// <param name="path">Comma delimited path.</param>
        /// <param name="param">Optinal.Set to "GetParam" by default.</param>
        /// <returns>XElement object</returns>
        private static XElement BuildYNCXElements(string path, object param = null)
        {
            XElement mn = null;
            XElement temp = null;
            foreach (string s in path.Split(new char[] { ',' }))
            {
                if (mn == null)
                {
                    mn = new XElement(s);
                    temp = mn;
                }
                else
                {
                    while (temp.Descendants().Count() > 0)
                    {
                        temp = temp.Descendants().First();
                    }
                    temp.Add(new XElement(s));
                }
            }
            temp.Descendants().First().Add(param ?? "GetParam");    //.Value = param;
            return mn;
        }

        #endregion

    }
}
