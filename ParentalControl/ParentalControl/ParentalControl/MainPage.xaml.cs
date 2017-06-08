using Xamarin.Forms;
using System.IO;
using System.Reflection;
using ParentalControl.Infrastructure;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
using ParentalControl.Models;
using System;

namespace ParentalControl
{
    public partial class MainPage : ContentPage
    {
        private Step currentStep = Step.Default;

        public MainPage()
        {
            InitializeComponent();
            RenderWebView();
        }

        public void RenderWebView()
        {
            RouterWebView.Source = "http://192.168.1.1";

            // (object o, WebNavigatedEventArgs navEvent)
            RouterWebView.Navigated += (obj, navEvent) => {
                var script = getScript(navEvent.Url);
                RouterWebView.Eval(script);
            };

            
        }

        public string loadScript(string fileName)
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

        public string getScript(string url)
        {
            // step 1: login
            if (url == "http://192.168.1.1/" && currentStep == Step.Default)
            {
                currentStep = Step.Login;
                return loadScript("Login.min.js");
            }
            // step 2: navigate to LAN
            if (url == "http://192.168.1.1/html/content.asp" && currentStep == Step.Login)
            {
                currentStep = Step.NavigateLAN;
                return loadScript("NavigateLAN.min.js");
            }

            // step 3: navigate to Ethernet
            if (url == "http://192.168.1.1/html/content.asp" && currentStep == Step.NavigateLAN)
            {
                currentStep = Step.NavigateEthernet;
                return loadScript("NavigateEthernet.min.js");
            }

            // step 4: send the device info back to the xamarin form
            if (url == "http://192.168.1.1/html/content.asp" && currentStep == Step.NavigateEthernet)
            {                
                return loadScript("DeviceInfo.min.js");
            }

            // step 5: deserialise the device info
            if (url.Contains("http://192.168.1.1/html/content.asp?deviceInfo="))
            {
                var jsonEncoded = url.Substring("http://192.168.1.1/html/content.asp?deviceInfo=".Length);
                var json = HttpUtility.UrlDecode(jsonEncoded);                
                var devices = JsonConvert.DeserializeObject<string[][]>(json);
                var deviceModels = GetDeviceModels(devices);
                currentStep = Step.DeviceInfo;
            }

            return string.Empty;
        }

        private List<DeviceModel> GetDeviceModels(string[][] devices)
        {
            var DeviceList = new List<DeviceModel>();

            for (int i = 0; i < devices.Length -1; i++)
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

            return DeviceList;
        }
    }    
}
