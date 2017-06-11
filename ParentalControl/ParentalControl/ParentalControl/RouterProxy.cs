using Newtonsoft.Json;
using ParentalControl.Infrastructure;
using ParentalControl.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Web;

namespace ParentalControl
{
    public class RouterProxy : INotifyPropertyChanged
    {
        private Step _currentStep = Step.Default;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<DeviceModel> DeviceList;

        public Step CurrentStep
        {
            get
            {
                return _currentStep;
            }
            set
            {
                _currentStep = value;
                OnPropertyChanged("CurrentStep");
            }
        }
        
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private string loadScript(string fileName)
        {
            var stringContent = string.Empty;

            //assembly.GetManifestResourceNames(); // Returns the names of all the resources in this assembly.
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;

            // the properies of the Login.min.js file has been set to Build Action: EmbeddedResource
            Stream stream = assembly.GetManifestResourceStream("ParentalControl.Scripts." + fileName);

            using (var reader = new StreamReader(stream))
            {
                stringContent = reader.ReadToEnd();
            }

            return stringContent;
        }

        private List<DeviceModel> GetDeviceList(string[][] devices)
        {
            var DeviceList = new List<DeviceModel>();

            if (devices != null)
            {
                for (int i = 0; i < devices.Length - 1; i++)
                {
                    DeviceList.Add(new DeviceModel
                    {
                        DeviceName = devices[i][1],
                        HostName = devices[i][2],
                        IPAdrress = devices[i][3],
                        MACAddress = devices[i][4],
                        LeaseDuration = Convert.ToInt32(devices[i][5])
                    });
                }
            }

            return DeviceList;
        }

        public string getScript(string url)
        {
            // step 1: login
            if (url == "http://192.168.1.1/" && CurrentStep == Step.Default)
            {
                CurrentStep = Step.Login;
                return loadScript("Login.min.js");
            }
            // step 2: navigate to LAN
            if (url == "http://192.168.1.1/html/content.asp" && CurrentStep == Step.Login)
            {
                CurrentStep = Step.NavigateLAN;
                return loadScript("NavigateLAN.min.js");
            }

            // step 3: navigate to Ethernet tab
            if (url == "http://192.168.1.1/html/content.asp" && CurrentStep == Step.NavigateLAN)
            {
                CurrentStep = Step.NavigateEthernet;
                return loadScript("NavigateEthernet.min.js");
            }

            // step 4: send the device info back to the xamarin form
            if (url == "http://192.168.1.1/html/content.asp" && CurrentStep == Step.NavigateEthernet)
            {
                return loadScript("DeviceInfo.min.js");
            }

            // step 5: deserialise the device info
            if (url.Contains("http://192.168.1.1/html/content.asp?deviceInfo="))
            {
                var jsonEncoded = url.Substring("http://192.168.1.1/html/content.asp?deviceInfo=".Length);
                var json = HttpUtility.UrlDecode(jsonEncoded);
                var devices = JsonConvert.DeserializeObject<string[][]>(json);
                this.DeviceList = GetDeviceList(devices);
                CurrentStep = Step.DeviceInfo;
            }

            // step 6: navigate to Basic > Wi-Fi
            if (url == "http://192.168.1.1/html/content.asp" && CurrentStep == Step.DeviceInfo)
            {
                CurrentStep = Step.NavigateBasicWiFi;
                return loadScript("NavigateBasicWiFi.min.js");
            }

            // step 7: navigate to Wi-Fi Filtering Tab
            if (url == "http://192.168.1.1/html/content.asp" && CurrentStep == Step.NavigateBasicWiFi)
            {
                CurrentStep = Step.NavigateWiFiFiltering;
                return loadScript("NavigateWiFiFiltering.min.js");
            }

            return string.Empty;
        }        
    }
}
