using System.Xml.Linq;

namespace YamahaAVLib.Models.Parameters
{
    interface IParameter
    {
        XName ParentTag { get; set; }
        string Func { get; set; }
        string ID { get; set; }
        string Value { get; set; }
        string Func_Ex { get; set; }
        string Icon_On { get; set; }
    }
}
