using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Windows.Input;
using System.IO;
using System.Threading.Tasks;
using QR_CodeScanner.Views;
using Android.Content;


namespace QR_CodeScanner.ViewModel
{
  

    public class QRGeneratorViewModel : BaseViewModel
    {
        string qrCodeTxt;
        string bgColor;
        string tcColor;
        string saveIsvisible;
        string shareIsVisible;
        string filepath;
        Stream stream;
        
        public ICommand ButtonShareClicked { get; set; }
        public ICommand ButtonSaveClicked { get; set; }

        [Obsolete]
        public QRGeneratorViewModel(string qrTxt)
        {
           
            tcColor = "Black";
            bgColor = "MintCream";
            saveIsvisible = "true";
            shareIsVisible = "true";
            qrCodeTxt = qrTxt;
            ButtonShareClicked = new Command(ShareQRImage);
            ButtonSaveClicked = new Command(SaveQR);
        }
        public string BGColor
        {
            get => bgColor;
            set => SetProperty(ref bgColor, value);
        }
        public string TCColor
        {
            get => tcColor;
            set => SetProperty(ref tcColor, value);
        }
        public string SaveIsVis
        {
            get => saveIsvisible;
            set => SetProperty(ref saveIsvisible, value);
        }
        public string ShareIsVis
        {
            get => shareIsVisible;
            set => SetProperty(ref shareIsVisible, value);
        }

        public string QRCodeText
        {
            get => qrCodeTxt;
            set => SetProperty(ref qrCodeTxt, value);
        }
       
        async void ShareQR(string filename, string filepath)
        {

            await Share.RequestAsync(new ShareFileRequest()
            {
                Title = filename,
                File = new ShareFile(filepath)
            });


        }
        async Task<string> CaptureScreenshot()
        {
            
            var screenshot = await Screenshot.CaptureAsync();
            stream = await screenshot.OpenReadAsync();

            var file = Path.Combine(FileSystem.CacheDirectory, "screensh.jpg");
            using (FileStream fs = File.Open(file, FileMode.Create))
            {
                await stream.CopyToAsync(fs);
                await fs.FlushAsync();
            }
            return file;


        }
        void ShareQRImage()
        {
            BGColor = "Black";
            TCColor = "White";
            ShareIsVis = "false";
            SaveIsVis = "false";

            string file = Convert.ToString(CaptureScreenshot());
             filepath = Path.Combine(FileSystem.CacheDirectory, "screensh.jpg");
            ShareQR(file, filepath);

            BGColor = "MintCream";
            TCColor = "Black";
            ShareIsVis = "true";
            SaveIsVis = "true";
        }

        [Obsolete]
        async void SaveQR()
        {
            BGColor = "Black";
            TCColor = "White";
            ShareIsVis = "false";
            SaveIsVis = "false";
             string file = await CaptureScreenshot();
            SaveImage(file);
           
           
            BGColor = "MintCream";
            TCColor = "Black";
            ShareIsVis = "true";
            SaveIsVis = "true";
            await App.Current.MainPage.DisplayAlert("QR-Code was saved in the Gallery", "", "OK");
        }
      
        [Obsolete]
        public void SaveImage(string filepath)
        {
            try
            {
                var imageData = File.ReadAllBytes(filepath);
                var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(
                Android.OS.Environment.DirectoryDcim);
                var pictures = dir.AbsolutePath;
                var filename = "QR-Code_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                var newFilepath = Path.Combine(pictures, filename);

                File.WriteAllBytes(newFilepath, imageData);
                //mediascan adds the saved image into the gallery
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Android.Net.Uri.FromFile(new Java.IO.File(newFilepath)));
                Android.App.Application.Context.SendBroadcast(mediaScanIntent);
            }
            catch(Exception)
            {
                App.Current.MainPage.DisplayAlert(" No Gallery found !!!", "", "OK");
            }
           
        }
    }

}
