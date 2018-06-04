using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace YamahaAVLib.Models
{
    /// <summary>
    /// Class represents Put_1, Cmd nodes.
    /// Its constructor parses these nodes and saves its attributes and values to class members.
    /// </summary>
    internal class Command
    {
        /// <summary>
        /// Gets tag name wich is Put_1 or Cmd
        /// </summary>
        public XName TagName { get; private set; }

        /// <summary>
        /// Gets value of Type attribute
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets value of ID attribute
        /// </summary>
        public string ID { get; private set; }

        /// <summary>
        /// Gets value of Func attribute
        /// </summary>
        public string Func { get; private set; }
        public List<string> Values { get; private set; } = new List<string>();

        /// <summary>
        /// Constructor. Parses Put_1 or Cmd nodes and saves its attributes and values to class members.
        /// </summary>
        /// <param name="cmd"></param>
        public Command(XElement cmd)
        {
            this.TagName = cmd.Name;
            this.Type = cmd.Attribute("Type")?.Value;
            this.ID = cmd.Attribute("ID")?.Value;
            this.Func = cmd.Attribute("Func")?.Value;
            this.Values = cmd.Value.Split(new string[] { ":" }, StringSplitOptions.None).ToList();
        }
    }
}
