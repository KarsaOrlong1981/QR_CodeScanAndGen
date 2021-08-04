using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

using QR_CodeScanner.ViewModel;
using QR_CodeScanner.Views;
using Xamarin.Essentials;
using System.Windows.Input;
using System.IO;
using System.Threading.Tasks;


namespace QR_CodeScanner.ViewModel
{
   
    public class QRGeneratorViewModel : BaseViewModel
    {
        string qrCodeTxt;
        string bgColor;
        string tcColor;
        string saveIsvisible;
        string shareIsVisible;
        Stream stream;
        public ICommand ButtonShareClicked { get; set; }
        public QRGeneratorViewModel(string qrTxt)
        {
            tcColor = "Black";
            bgColor = "MintCream";
            saveIsvisible = "true";
            shareIsVisible = "true";
            qrCodeTxt = qrTxt;
            ButtonShareClicked = new Command(ShareQRImage);
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

            var file = Path.Combine(FileSystem.CacheDirectory, "screenshot.png");
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
            var filepath = Path.Combine(FileSystem.CacheDirectory, "screenshot.png");
            ShareQR(file, filepath);

            BGColor = "MintCream";
            TCColor = "Black";
            ShareIsVis = "true";
            SaveIsVis = "true";
        }
       
    }
}
