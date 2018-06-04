using System.Xml.Linq;
using YamahaAVLib.Config;
using YamahaAVLib.ENums;

namespace YamahaAVLib.YNC
{
    /// <summary>
    /// Initial unit response contains xml description of all devices, its status, and command definitions.
    /// Each device contains Cmd_List node with Define child nodes. These contains function/command definitions.
    /// This class provides functionality for getting those definitions based on device attributes and function ID.
    /// </summary>
    public abstract class YNCDefineFuncSelector
    {
        /// <summary>
        /// Gets or sets unit response contains xml description of all devices
        /// </summary>
        public static XElement UnitDescription { get; set; }

        #region Command Definition Base
        /// <summary>
        /// Implements basic functionality for getting function definitions by ID for devices
        /// </summary>
        /// <param name="attr">DeviceAttribute class containing Node name, attribute name, attribute value defining device, Define node name, and Define attribute</param>
        /// <param name="id">Function id</param>
        /// <returns>comma separated string</returns>
        private static string GetDefinitionBase(DeviceAttribute attr, string id)
        {
            return (new YQuery(Atomics.UnitDescription)).GetNode(attr.TagName, attr.Name, attr.Value).GetNode(attr.DefineTag, attr.DefineAttribute, id).Value;
        }

        /// <summary>
        /// Gets function definition by ID for System device
        /// </summary>
        /// <param name="id">function ID</param>
        /// <returns>comma separated string</returns>
        internal static string SystemFunction(string id)
        {
            return GetDefinitionBase(Atomics.Unit, id);
        }

        /// <summary>
        /// Gets function definition by ID for Main Zone device
        /// </summary>
        /// <param name="id">function ID</param>
        /// <returns>comma separated string</returns>
        internal static string MainZoneFunction(string id)
        {
            return GetDefinitionBase(Atomics.Subunit, id);
        }

        /// <summary>
        /// Gets function definition by ID for Radio Tuner device
        /// </summary>
        /// <param name="id">function ID</param>
        /// <returns>comma separated string</returns>
        internal static string TunerFunction(string id)
        {
            return GetDefinitionBase(Atomics.Tuner, id);
        }

        /// <summary>
        /// Gets function definition by ID for AirPlay device
        /// </summary>
        /// <param name="id">function ID</param>
        /// <returns>comma separated string</returns>
        internal static string AirPlayFunction(string id)
        {
            return GetDefinitionBase(Atomics.AirPlay, id);
        }

        /// <summary>
        /// Gets function definition by ID for iPod device
        /// </summary>
        /// <param name="id">function ID</param>
        /// <returns>comma separated string</returns>
        internal static string IPodFunction(string id)
        {
            return GetDefinitionBase(Atomics.iPod, id);
        }

        /// <summary>
        /// Gets function definition by ID for USB device
        /// </summary>
        /// <param name="id">function ID</param>
        /// <returns>comma separated string</returns>
        internal static string USBFunction(string id)
        {
            return GetDefinitionBase(Atomics.USB, id);
        }

        /// <summary>
        /// Gets function definition by ID for Net Radio device
        /// </summary>
        /// <param name="id">function ID</param>
        /// <returns>comma separated string</returns>
        internal static string NETRadioFunction(string id)
        {
            return GetDefinitionBase(Atomics.NetRadio, id);
        }

        /// <summary>
        /// Gets function definition by ID for DLNA device
        /// </summary>
        /// <param name="id">function ID</param>
        /// <returns>comma separated string</returns>
        internal static string DLNAFunction(string id)
        {
            return GetDefinitionBase(Atomics.DLNA, id);
        }
        #endregion

        public static string SelectCmdFunctionPath(FunctionType funcType, string id)
        {
            string path = null;

            if ((int)funcType <=  (int)FunctionType.SysDMCControl)
            {
                path = YNCDefineFuncSelector.SystemFunction(id);
            }
            else if ((int)FunctionType.SubunitInput <= (int)funcType && (int)funcType <= (int)FunctionType.SubunitHDMIStandbyThrough)
            {
                path = YNCDefineFuncSelector.MainZoneFunction(id);
            }
            else if ((int)FunctionType.TunerStatus <= (int)funcType && (int)funcType <= (int)FunctionType.TunerPlayInfoStatusStereo)
            {
                path = YNCDefineFuncSelector.TunerFunction(id);
            }
            else if ((int)FunctionType.AirPlayStatus <= (int)funcType && (int)funcType <= (int)FunctionType.AirPlayPlayInfoInputLogoURL)
            {
                path = YNCDefineFuncSelector.AirPlayFunction(id);
            }
            else if ((int)FunctionType.iPodInit <= (int)funcType && (int)funcType <= (int)FunctionType.iPodListBrowseInfoMaxLine)
            {
                path = YNCDefineFuncSelector.IPodFunction(id);
            }
            else if ((int)FunctionType.USBStatus <= (int)funcType && (int)funcType <= (int)FunctionType.USBListBrowseInfoMaxLine)
            {
                path = YNCDefineFuncSelector.USBFunction(id);
            }
            else if ((int)FunctionType.NETRadioStatus <= (int)funcType && (int)funcType <= (int)FunctionType.NETRadioListBrowseInfoMaxLine)
            {
                path = YNCDefineFuncSelector.NETRadioFunction(id);
            }
            else if ((int)FunctionType.DLNAStatus <= (int)funcType)
            {
                path = YNCDefineFuncSelector.DLNAFunction(id);
            }

            return path;
        }
    }
}
