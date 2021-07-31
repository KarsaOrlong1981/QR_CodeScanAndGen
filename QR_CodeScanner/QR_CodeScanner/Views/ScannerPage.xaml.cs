using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using Xamarin.Essentials;

namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScannerPage : ContentPage
    {
        public ScannerPage()
        {
            InitializeComponent();
        }
        public void scanView_OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            { 
                
               await OpenBrowser(result.Text);
              lab_Label.Text = result.Text; 
            });
        }
        public async Task OpenBrowser(string uri)
        {
            try
            {
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch(Exception)
            {
               
            }

                
        }
    }
}