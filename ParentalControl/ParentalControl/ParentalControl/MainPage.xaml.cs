using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParentalControl
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            RenderWebView();
        }

        public void RenderWebView()
        {
            var script = "javascript:document.getElementById('txt_Username').setAttribute('value','test')";
            RouterWebView.Source = "http://192.168.1.1";
            // (object o, WebNavigatedEventArgs navEvent)
            RouterWebView.Navigated += (obj, navEvent) => {
                RouterWebView.Eval(script);
            };
        }
    }
}
