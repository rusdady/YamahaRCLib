using System;
using System.Xml.Linq;
using YamahaAVLib.ENums;

namespace YamahaAVLib.EveArgs
{
    public class CommEventArgs : EventArgs
    {
        public CommandListFunctionType YNCFunction { get; set; }
        public XElement UnitDescription { get; set; }
        public XElement CommandResponse { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
