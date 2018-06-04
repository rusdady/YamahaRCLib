using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using YamahaAVLib.Classes;
using YamahaAVLib.YNC;

namespace YamahaAVLib.Models.Scene
{
    public class Scene : TypedXMLResponseParser
    {
        [YNCTag("Feature_Availability")]
        public string Availability { get; set; }

        [YNCTag("Zone")]
        public string Zone { get; set; }

        [YNCTag("Scene")]
        public List<SceneItem> Scenes { get; set; } = new List<SceneItem>();

        [YNCTag("Volume_Existence")]
        public string VolumeAvailable { get; set; }

        public XElement _xdocument { get; set; } = null;

        /// <summary>
        /// Parameterless constructor required for generic operations
        /// </summary>
        public Scene() { }

        public Scene(XElement xmlResponse)
        {
            this._xdocument = xmlResponse;
        }

        public Scene Parse()
        {
            Scene result = null;
            Type type = typeof(Scene);
            result = (Scene)Parse(type.GetProperties(), this._xdocument);

            List<XElement> lst = this._xdocument.Descendants().Where(x => x.Name.ToString().StartsWith("Scene_")).ToList();
            result.Scenes = new List<SceneItem>();

            foreach (XElement xe in lst)
            {
                result.Scenes.Add(new SceneItem() { Parameter = xe.Name.ToString().Replace("_", " "), Title = xe.Value });
            }

            return result;
        }
    }
}

/*
<YAMAHA_AV rsp="GET" RC="0">
  <Main_Zone>
    <Config>
      <Feature_Availability>Ready</Feature_Availability>
      <Name>
        <Zone>Main</Zone>
        <Scene>
          <Scene_1>BD/DVD</Scene_1>
          <Scene_2>TV</Scene_2>
          <Scene_3>NET</Scene_3>
          <Scene_4>RADIO</Scene_4>
        </Scene>
      </Name>
      <Volume_Existence>Exist</Volume_Existence>
    </Config>
  </Main_Zone>
</YAMAHA_AV> 
*/
