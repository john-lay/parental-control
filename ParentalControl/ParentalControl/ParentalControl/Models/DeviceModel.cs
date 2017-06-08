
namespace ParentalControl.Models
{
    public class DeviceModel
    {
        public string DeviceName { get; set; }
        public string HostName { get; set; }
        public string IPAdrress { get; set; }
        public string MACAddress { get; set; }
        public int LeaseDuration { get; set; }
        public bool WiFiEnabled { get; set; }
    }
}
