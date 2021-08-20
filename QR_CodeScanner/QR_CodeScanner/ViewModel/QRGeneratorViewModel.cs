using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Windows.Input;
using System.IO;
using System.Threading.Tasks;
using QR_CodeScanner.Views;
using Android.Content;
using Android.App;
using Android.Widget;

namespace QR_CodeScanner.ViewModel
{
  

    public class QRGeneratorViewModel : BaseViewModel
    {
        string[] splitVCard;
        string text;
        string labelText;
        string qrCodeTxt;
        string bgColor;
        string tcColor;
       
        string saveIsvisible;
        string shareIsVisible;
        string filepath;
        string vcard1, vcard2, vcard3, vcard4, vcard5, vcard6, vcard7,vcard7Link, vcard8, vcard9,vcard9Link, vcard10, vcard11,vcard11Link, vcard12, vcard13;
        int fontSize;
        Stream stream;
        
        public ICommand ButtonShareClicked { get; set; }
        public ICommand ButtonSaveClicked { get; set; }
       
        [Obsolete]
        public QRGeneratorViewModel(string qrTxt,bool isContact,bool isEvent,bool isPhoneNumber,bool isEmail)
        {
           
            if (isContact)
            {
                FontSizeQR = 13;
                    splitVCard = qrTxt.Split(':', '\n');


                    LabelText = "";
                    VCard1 = splitVCard[0] + ":" + splitVCard[1] + "\n";
                    VCard2 = splitVCard[2] + ":" + splitVCard[3] + "\n";
                    VCard3 = splitVCard[4] + ":" + splitVCard[5] + "\n";
                    VCard4 = splitVCard[6] + ":" + splitVCard[7] + "\n";
                    VCard5 = splitVCard[8] + ":" + splitVCard[9] + "\n";
                    VCard6 = splitVCard[10] + ":";
                    VCard7 = splitVCard[11] + "\n"; //PhoneNumber
                    VCard7Link = "tel:" + splitVCard[11];
                    VCard8 = splitVCard[12] + ":";
                    VCard9 = splitVCard[13] + "\n"; //Website
                    VCard9Link = "https://" + splitVCard[13];
                    VCard10 = splitVCard[14] + ":";
                    VCard11 = splitVCard[15] + "\n"; //Email
                    VCard11Link = "mailto:" + splitVCard[15];
                    VCard12 = splitVCard[16] + ":" + splitVCard[17] + "\n";
                    VCard13 = splitVCard[18] + ":" + splitVCard[19] + "\n";

                    Text = VCard1 + VCard2 + VCard3 + VCard4 + VCard5 + VCard6 + VCard7 + VCard8 + VCard9 + VCard10 + VCard11 + VCard12 + VCard13;

                VCard1 = splitVCard[0] + ":" + splitVCard[1] + " " ;
                VCard2 = splitVCard[2] + ":" + splitVCard[3] + " ";
                VCard3 = splitVCard[4] + ":" + splitVCard[5] + " ";
                VCard4 = splitVCard[6] + ":" + splitVCard[7] + " ";
                VCard5 = splitVCard[8] + ":" + splitVCard[9] + " ";
                VCard6 = splitVCard[10] + ":";
                VCard7 = splitVCard[11] + " "; //PhoneNumber
                VCard7Link = "tel:" + splitVCard[11] + " ";
                VCard8 = splitVCard[12] + ":";
                VCard9 = splitVCard[13] + " "; //Website
                VCard9Link = "https://" + splitVCard[13] + " ";
                VCard10 = splitVCard[14] + ":";
                VCard11 = splitVCard[15] + " "; //Email
                VCard11Link = "mailto:" + splitVCard[15] + " ";
                VCard12 = splitVCard[16] + ":" + splitVCard[17] + " ";
                VCard13 = splitVCard[18] + ":" + splitVCard[19] ;
                
               
            }
           
            else
            {
                if (isEvent)
                {
                    FontSizeQR = 10;
                }
               
                Text = qrTxt;
                LabelText = qrTxt;

                VCard1 = "";
                VCard2 = "";
                VCard3 = "";
                VCard4 = "";
                VCard5 = "";
                VCard6 = "";
                
                if (isPhoneNumber)
                {
                    LabelText = "TEL: ";
                    VCard7 = qrTxt;
                    VCard7Link = "tel:" + qrTxt;
                }
                else
                {
                    VCard7 = "";
                    VCard7Link = "";
                }
               
                VCard8 = "";
                VCard9 = "";
                VCard9Link = "";
                VCard10 = "";
                if (isEmail)
                {
                    
                        LabelText = "Email: ";
                        VCard11 = qrTxt;
                        VCard11Link = "mailto:" + qrTxt;
                     
                }
                else
                {
                    VCard11 = "";
                    VCard11Link = "";
                }
                VCard12 = "";
                VCard13 = "";

               
               
            }
            
            tcColor = "Black";
            bgColor = "MintCream";
           
            saveIsvisible = "true";
            shareIsVisible = "true";
            ButtonShareClicked = new Command(ShareQRImage);
            ButtonSaveClicked = new Command(SaveQR);
        }
        public string LabelText
        {
            get => labelText;
            set => SetProperty(ref labelText, value);
        }
        public int FontSizeQR
        {
            get => fontSize;
            set => SetProperty(ref fontSize, value);
        }
        public string Text
        {
            get => text ;
            set => SetProperty(ref text, value);
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
        public string VCard1
        {
            get => vcard1;
            set => SetProperty(ref vcard1, value);
        }
        public string VCard2
        {
            get => vcard2;
            set => SetProperty(ref vcard2, value);
        }
        public string VCard3
        {
            get => vcard3;
            set => SetProperty(ref vcard3, value);
        }
        public string VCard4
        {
            get => vcard4;
            set => SetProperty(ref vcard4, value);
        }
        public string VCard5
        {
            get => vcard5;
            set => SetProperty(ref vcard5, value);
        }
        public string VCard6
        {
            get => vcard6;
            set => SetProperty(ref vcard6, value);
        }
        public string VCard7
        {
            get => vcard7;
            set => SetProperty(ref vcard7, value);
        }
        public string VCard7Link
        {
            get => vcard7Link;
            set => SetProperty(ref vcard7Link, value);
        }
        

        public string VCard8
        {
            get => vcard8;
            set => SetProperty(ref vcard8, value);
        }
        public string VCard9
        {
            get => vcard9;
            set => SetProperty(ref vcard9, value);
        }
        public string VCard9Link
        {
            get => vcard9Link;
            set => SetProperty(ref vcard9Link, value);
        }
        public string VCard10
        {
            get => vcard10;
            set => SetProperty(ref vcard10, value);
        }
        public string VCard11
        {
            get => vcard11;
            set => SetProperty(ref vcard11, value);
        }
        public string VCard11Link
        {
            get => vcard11Link;
            set => SetProperty(ref vcard11Link, value);
        }
        public string VCard12
        {
            get => vcard12;
            set => SetProperty(ref vcard12, value);
        }
        public string VCard13
        {
            get => vcard13;
            set => SetProperty(ref vcard13, value);
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
             filepath = Path.Combine(FileSystem.CacheDirectory, "screenshot.png");
            ShareQR(file, filepath);

           
            BGColor = "MintCream";
            TCColor = "Black";
            ShareIsVis = "true";
            SaveIsVis = "true";
            
        }

        [Obsolete]
        async  void SaveQR()
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
            var activity = Forms.Context as Activity;
            Toast.MakeText(activity, "Qr-Code was saved in Gallery", ToastLength.Short).Show();
           // await App.Current.MainPage.DisplayAlert("QR-Code was saved in the Gallery", "", "OK");
        }

        [Obsolete]
        public void SaveImage(string filepath)
        {
            try
            {
                var imageData = File.ReadAllBytes(filepath);
                var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures);
                var pictures = dir.AbsolutePath;
                var filename = "QR_Code_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";
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
