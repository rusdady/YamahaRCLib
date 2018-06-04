using YamahaAVLib.ENums;

namespace YamahaAVLib.Models
{
    public class DeviceStatus
    {
        public string DeviceName { get; set; }
        public bool Ready { get; set; } = false;

        public DeviceStatus(string deviceName, string status)
        {
            DeviceName = deviceName;
            if (status.Equals(YNCParam.Ready)) Ready = true;
        }
    }
}
