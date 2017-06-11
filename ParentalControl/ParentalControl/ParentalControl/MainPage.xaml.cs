using Xamarin.Forms;
using ParentalControl.Infrastructure;
using System;
using System.ComponentModel;
using ParentalControl.Models;
using System.Collections.Generic;

namespace ParentalControl
{
    public partial class MainPage : ContentPage
    {
        private RouterProxy routerProxy;

        public MainPage()
        {
            InitializeComponent();
            this.routerProxy = new RouterProxy();
            routerProxy.PropertyChanged += RouterProxy_PropertyChanged;
            RenderWebView();
        }

        private void RouterProxy_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (routerProxy.CurrentStep == Step.DeviceInfo)
            {
                RouterWebView.Source = "http://192.168.1.1/html/content.asp";
                // show the list of devices
            }
        }

        public void RenderWebView()
        {
            RouterWebView.Source = "http://192.168.1.1";

            // (object o, WebNavigatedEventArgs navEvent)
            RouterWebView.Navigated += (obj, navEvent) => {
                var script = routerProxy.getScript(navEvent.Url);
                RouterWebView.Eval(script);
            };
        }        
    }    
}
