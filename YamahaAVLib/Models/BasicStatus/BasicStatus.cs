using System;
using System.Xml.Linq;
using YamahaAVLib.Classes;
using YamahaAVLib.YNC;

namespace YamahaAVLib.Models.BasicStatus
{
    /// <summary>
    /// Class parses xml response from Communication class CommandListFunctionType.GetMainZoneBasicStatus request and saves values 
    /// in its properties.
    /// </summary>
    public class BasicStatus : TypedXMLResponseParser
    {
        [YNCTag("Power_Control")]
        public PowerControl PowerControl { get; set; } = new PowerControl();

        [YNCTag("Volume")]
        public Volume Volume { get; set; } = new Volume();

        [YNCTag("Input")]
        public Input Input { get; set; } = new Input();

        [YNCTag("Surround")]
        public Surround Surround { get; set; } = new Surround();

        [YNCTag("Sound_Video")]
        public SoundVideo SoundVideo { get; set; } = new SoundVideo();


        private XElement _xdocument;
        
        public BasicStatus()
        {

        }

        public BasicStatus(XElement xdocument)
        {
            this._xdocument = xdocument;
        }


        public BasicStatus Parse()
        {
            Type type = typeof(BasicStatus);
            return (BasicStatus)Parse(type.GetProperties(), _xdocument);
        }

    }
}
