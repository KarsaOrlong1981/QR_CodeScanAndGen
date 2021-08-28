using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QR_CodeScanner.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private string PhotoPath;
       
        public MainPage()
        {
            InitializeComponent();
            
        }

        [Obsolete]
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

        [Obsolete]
        private void ToolbarItemGenerator_Clicked(object sender, EventArgs e)
        {
            CallQRVersionPage();
        }

       
         void btn_Scann_Clicked(object sender, EventArgs e)
        {
           CallScannerPage();
        }
        async Task UseCameratoScan()
        {
            try
            {
                await MediaPicker.CapturePhotoAsync();
                
                //Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
            }
            catch 
            {
                await DisplayAlert("nOpe", "nope", "OK");
                // Feature is not supported on the device
            }
        }
        async Task LoadVideoAsync(FileResult video)
        {
            // canceled
            if (video == null)
            {
                PhotoPath = null;
                return;
            }
            // save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, video.FileName);
            using (var stream = await video.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

           PhotoPath = newFile;
        }
    }
}