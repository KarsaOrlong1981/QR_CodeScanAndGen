using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRGeneratorPage : ContentPage
    {
       
        
        Image image;
        
        public QRGeneratorPage(string text)
        {
            InitializeComponent();
            barCode.BarcodeValue = text;
            lab_Gen.Text = text;
           
          
            image = new Image() 
            { 
               
            MinimumHeightRequest = 400,
            MinimumWidthRequest = 400 
            };
            
            
        }
        async Task CaptureScreenshot()
        {
            var screenshot = await Screenshot.CaptureAsync();
            var stream = await screenshot.OpenReadAsync();

            image.Source = ImageSource.FromStream(() => stream);
        }
        //Ermöglicht das Teilen einer Notiz über andere Apps
        async void ShareQR(string message)
        {

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = message,
                Title = "Share!"
            });
      
        }
        private void btn_Share_Clicked(object sender, EventArgs e)
        {
            
            ShareQR(barCode.BarcodeValue);
        }
    }
}