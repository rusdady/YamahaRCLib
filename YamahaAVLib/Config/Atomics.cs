using System.Xml.Linq;

namespace YamahaAVLib.Config
{
    internal static class Atomics
    {
        public static XElement UnitDescription { get; set; } = null;
        public static string HostNameOrIPAddress { get; set; }

        public const string UnitDescriptionPath = @"YamahaRemoteControl/desc.xml";
        public const string RemoteControlPath = @"YamahaRemoteControl/ctrl";
        public const string UserAgent = @"AVcontrol/1.03 CFNetwork/485.12.30 Darwin/10.4.0";
        public const string ContentType = @"text/xml; charset=UTF-8";
        public const string Param = @"Param_1";
        public static int StatusCheckInterval { get; set; } = 3000;

        public static DeviceAttribute Unit => new DeviceAttribute() { TagName = "Menu", Name = "Func", Value = "Unit", DefineTag = "Define", DefineAttribute = "ID" };
        public static DeviceAttribute Subunit => new DeviceAttribute() { TagName = "Menu", Name = "Func", Value = "Subunit", DefineTag = "Define", DefineAttribute = "ID" };
        public static DeviceAttribute Tuner => new DeviceAttribute() { TagName = "Menu", Name = "Func_Ex", Value = "SD_Tuner", DefineTag = "Define", DefineAttribute = "ID" };
        public static DeviceAttribute AirPlay => new DeviceAttribute() { TagName = "Menu", Name = "Func_Ex", Value = "SD_AirPlay", DefineTag = "Define", DefineAttribute = "ID" };
        public static DeviceAttribute iPod => new DeviceAttribute() { TagName = "Menu", Name = "Func_Ex", Value = "SD_iPod_USB", DefineTag = "Define", DefineAttribute = "ID" };
        public static DeviceAttribute USB => new DeviceAttribute() { TagName = "Menu", Name = "Func_Ex", Value = "SD_USB", DefineTag = "Define", DefineAttribute = "ID" };
        public static DeviceAttribute NetRadio => new DeviceAttribute() { TagName = "Menu", Name = "Func_Ex", Value = "SD_vTuner", DefineTag = "Define", DefineAttribute = "ID" };
        public static DeviceAttribute DLNA => new DeviceAttribute() { TagName = "Menu", Name = "Func_Ex", Value = "SD_DLNA", DefineTag = "Define", DefineAttribute = "ID" };
    }
}
