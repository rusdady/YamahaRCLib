using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace YamahaAVLib.YNC
{
    /// <summary>
    /// Class provides functionality to extract XML nodes by node name, attribute name and attribute value 
    /// from Unit Response xml document.
    /// </summary>
    public class YQuery
    {
        /// <summary>
        /// Gets single node and its child nodes. Should be used with GetNode function.
        /// </summary>
        public XElement Node { get; private set; }

        /// <summary>
        /// Gets value of the node if node is last child in tree.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Gets list of found nodes with GetChildNodes method.
        /// </summary>
        public List<XElement> XElements { get; private set; } = new List<XElement>();

        private XElement _rootElement = null;

        /// <summary>
        /// Constructor. Accepts Unit Response xml document.
        /// </summary>
        /// <param name="element"></param>
        public YQuery(XElement element)
        {
            this._rootElement = element;
        }

        /// <summary>
        /// Gets first child node of the element parameter with nodeName node name that has matched attribute name and attribute value.
        /// Found node passed to Node property and it value to Value property.
        /// </summary>
        /// <param name="nodeName">Wanted child node which tag name matches nodeName</param>
        /// <param name="attribute">Wanted child node that has attribute with name as in attribute parameter</param>
        /// <param name="attr_value">Wanted child node that has attribute with name and value as in attrib_value parameter</param>
        /// <returns>returns self</returns>
        public YQuery GetNode(string nodeName, string attribute, string attr_value)
        {
            if (this.Node == null) this.Node = this._rootElement.Descendants(nodeName).FirstOrDefault(el => el.Attribute(attribute) != null && el.Attribute(attribute).Value == attr_value);
            else this.Node = this.Node.Descendants(nodeName).FirstOrDefault(el => el.Attribute(attribute) != null && el.Attribute(attribute).Value == attr_value);
            this.Value = this.Node == null ? string.Empty : this.Node.Value;
            return this;
        }

        /// <summary>
        /// Gets list of child node of the element parameter with nodeName node name that has matched attribute name and attribute value.
        /// Found nodes passed to XElements property.
        /// </summary>
        /// <param name="nodeName">Wanted child node which tag name matches nodeName</param>
        /// <param name="attribute">Optional. Wanted child node that has attribute with name as in attribute parameter</param>
        /// <param name="attr_value">Optional. Wanted child node that has attribute with name and value as in attrib_value parameter</param>
        /// <returns>returns self</returns>
        public YQuery GetChildNodes(string nodeName, string attribute = null, string attr_value = null)
        {
            if (attribute != null)
            {
                if (this.XElements.Count() == 0) this.XElements = this._rootElement.Elements(nodeName).Where(x => x.Attribute(attribute) != null && x.Attribute(attribute).Value == attr_value).ToList();
                else
                {
                    List<XElement> lxel = this.XElements[0].Elements(nodeName).ToList();
                    this.XElements = lxel.Where(x => x.Attribute(attribute) != null && x.Attribute(attribute).Value == attr_value).ToList();
                }
            }
            else
            { 
                if (this.XElements.Count() == 0) this.XElements = this._rootElement.Elements(nodeName).ToList();
                else this.XElements = this.XElements[0].Elements(nodeName).ToList();
            }

            return this;
        }
    }
}
