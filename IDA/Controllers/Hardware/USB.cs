using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace IDA.Controllers.Hardware
{
    internal class Usb
    {

      public  static List<UsbDeviceInfo> GetUsbDevices()
        {
            List<UsbDeviceInfo> devices = new List<UsbDeviceInfo>();

            var searcher = new ManagementObjectSearcher(@"Select * From Win32_SerialPort");

            foreach (var device in searcher.Get())
            {
                devices.Add(new UsbDeviceInfo(
                (string)device.GetPropertyValue("DeviceId"),
                (string)device.GetPropertyValue("PNPDeviceID"),
                (string)device.GetPropertyValue("Description"),
                (string)device.GetPropertyValue("Name")
                ));
            }

            return devices;
        }

        internal class UsbDeviceInfo
        {
            public UsbDeviceInfo(string deviceId, string pnpDeviceId, string description, string name)
            {
                this.DeviceId = deviceId;
                this.PnpDeviceId = pnpDeviceId;
                this.Description = description;
                this.Name = name;
            }
            public string DeviceId { get; private set; }
            public string PnpDeviceId { get; private set; }
            public string Description { get; private set; }
            public string Name { get; private set; }

        }

    }
}
