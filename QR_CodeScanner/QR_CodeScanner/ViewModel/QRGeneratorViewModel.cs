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
using System.Globalization;
using QR_CodeScanner.Model;
using System.Collections.ObjectModel;
using SQLite;
using Android.Graphics;

namespace QR_CodeScanner.ViewModel
{
    public class QRGeneratorViewModel : BaseViewModel
    {
        string[] splitVCard;
        string text;
        string labelText;
        private readonly string number;
        string bgColor;
        string tcColor;
        string qrCode;
        string saveIsvisible;
        string shareIsVisible;
        string filepath;
        string vcard1, vcard2, vcard3, vcard4, vcard5, vcard6, vcard7, vcard7Link, vcard8, vcard9, vcard9Link, vcard10, vcard11, vcard11Link, vcard12, vcard13;
        int fontSize;
        ShareContent share;
        Stream stream;
        CultureLang culture;
        QRImage qrImage;
        private bool wlan;
        private bool website;
        private bool contact;
        private bool eventX;
        private bool phonenumber;
        private bool email;
        private bool sms;
        private bool food;
        private bool browser;

        public ICommand ButtonShareClicked { get; set; }
        public ICommand ButtonSaveClicked { get; set; }
        [Obsolete]
        public QRGeneratorViewModel(string qrTxt, bool isWlan, bool isWebsite, bool isContact, bool isEvent, bool isPhoneNumber, bool isEmail, bool isSMS, bool isFood, bool isBrowser, string phoneNumberString, bool fromProgress)
        {
            qrImage = new QRImage();
            //this creates the Barcode text
            Text = qrTxt;
            number = phoneNumberString;
            wlan = isWlan;
            website = isWebsite;
            contact = isContact;
            eventX = isEvent;
            phonenumber = isPhoneNumber;
            email = isEmail;
            sms = isSMS;
            food = isFood;
            browser = isBrowser;
            if (fromProgress == false)
            {
                GetImageAndTextProgress();
            }
            share = new ShareContent();
            qrCode = qrTxt;
            FontSizeQR = 20;
            LabelText = "";
            culture = new CultureLang();

            if (isWlan)
            {
                Text = qrTxt;
            }
            if (isWebsite)
            {
                Text = qrTxt;
            }
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

                VCard1 = splitVCard[0] + ":" + splitVCard[1] + " ";
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
                VCard13 = splitVCard[18] + ":" + splitVCard[19];
            }
            else
            {
                if (isEvent)
                {
                    FontSizeQR = 10;
                }
                // Text = qrTxt;
                LabelText = qrTxt;

                if (isPhoneNumber)
                {
                    LabelText = "TEL: ";
                    VCard7 = qrTxt;
                    VCard7Link = "tel:" + qrTxt;
                }
                if (isEmail)
                {
                    LabelText = "Email: ";
                    VCard11 = qrTxt;
                    VCard11Link = "mailto:" + qrTxt;
                }
                if (isSMS)
                {

                    LabelText = "SMS: ";
                    VCard10 = qrTxt;
                    VCard11 = number;
                    VCard11Link = "smsto:" + number + ":" + qrTxt;
                    Text = "smsto:" + number + ":" + qrTxt;
                }
            }
            tcColor = "Black";
            bgColor = "White";
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
            get => text;
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

        [Obsolete]
        private void GetImageAndTextProgress()
        {
            string eventQRString = string.Empty;
            string text = Text;
            if (wlan == true)
                eventQRString = "Wlan";
            if (website == true)
                eventQRString = "Website";
            if (contact == true)
                eventQRString = "Contact";
            if (eventX == true)
                eventQRString = "Event";
            if (phonenumber == true)
                eventQRString = "Phonenumber";
            if (email == true)
                eventQRString = "Email";
            if (sms == true)
            {
                eventQRString = "SMS";
                text = "smsto:" + number + ":" + Text;
            }
            if (food == true)
                eventQRString = "Food";
            if (browser == true)
                eventQRString = "Browser";
            if (eventQRString != "Wlan" && eventQRString != "Website" && eventQRString != "Contact" && eventQRString != "Event" && eventQRString != "Phonenumber" &&
               eventQRString != "Email" && eventQRString != "SMS" && eventQRString != "Food" && eventQRString != "Browser")
            {
                eventQRString = "Text";
            }
            new HistoryPage(text, eventQRString, true);
        }

        [Obsolete]
        async void ShareQRImage()
        {
            //this overrides the filePath and set an new Image and text.
            qrImage.ShareQRAsImage(Text);
            filepath = System.IO.Path.Combine(FileSystem.CacheDirectory, "screenshot.png");
            await share.ShareFile(Text, filepath);
        }

        [Obsolete]
        async void SaveQR()
        {
            await qrImage.SaveQRAsImage(Text);
            var activity = Forms.Context as Activity;
            if (culture.GetCulture() == "de")
                Toast.MakeText(activity, "Qr-Code in der Gallrie gespeichert", ToastLength.Short).Show();
            else
                Toast.MakeText(activity, "Qr-Code was saved in Gallery", ToastLength.Short).Show();
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
                var newFilepath = System.IO.Path.Combine(pictures, filename);

                File.WriteAllBytes(newFilepath, imageData);
                //mediascan adds the saved image into the gallery
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Android.Net.Uri.FromFile(new Java.IO.File(newFilepath)));
                Android.App.Application.Context.SendBroadcast(mediaScanIntent);
            }
            catch
            {
                if (culture.GetCulture() == "de")
                    App.Current.MainPage.DisplayAlert("Kein Pictures Ordner auf dem Gerät.", "", "OK");
                else
                    App.Current.MainPage.DisplayAlert("No Pictures Folder on Device.", "", "OK");
            }
        }
    }

}
