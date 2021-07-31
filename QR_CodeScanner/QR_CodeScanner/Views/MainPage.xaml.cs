using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QR_CodeScanner.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
         async void CallQRVersionPage()
        {
            QRVersionPage call = new QRVersionPage();
            await Navigation.PushAsync(call);
        }
        async void CallScannerPage()
        {
            ScannerPage call = new ScannerPage();
            await Navigation.PushAsync(call);
        }

        private void ToolbarItemGenerator_Clicked(object sender, EventArgs e)
        {
            CallQRVersionPage();
        }

       
        private void btn_Scann_Clicked(object sender, EventArgs e)
        {
            CallScannerPage();
        }
    }
}