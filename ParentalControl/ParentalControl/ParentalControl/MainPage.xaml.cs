using Xamarin.Forms;
using System.IO;
using System.Reflection;

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
            var loginScript = getLoginScript();
            var script = getLoginScript();
            RouterWebView.Source = "http://192.168.1.1";
            // (object o, WebNavigatedEventArgs navEvent)
            RouterWebView.Navigated += (obj, navEvent) => {
                RouterWebView.Eval(script);
            };
        }

        public string getLoginScript()
        {
            var stringContent = string.Empty;
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            //assembly.GetManifestResourceNames(); // Returns the names of all the resources in this assembly.
            // the properies of the Login.min.js file has been set to Build Action: EmbeddedResource
            Stream stream = assembly.GetManifestResourceStream("ParentalControl.Scripts.Login.min.js");
            using (var reader = new StreamReader(stream))
            {
                stringContent = reader.ReadToEnd();
            }

            return stringContent;
        }
    }
}
