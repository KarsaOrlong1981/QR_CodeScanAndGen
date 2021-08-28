using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using QR_CodeScanner.ViewModel;
using QR_CodeScanner.Views;
using Xamarin.Forms;
using QR_CodeScanner.Model;

namespace QR_CodeScanner.ViewModel
{
    public class WLanViewModel : BaseViewModel
    {
        CultureLang culture;
        string ssid;
        string wpa;
        string password, passwordCulture, titleCulture;
        string wlanKey;
        string generate, buttonCulture;
        string readOnly;
        public ICommand ButtonGenerateClicked { get; set; }
        public ICommand ButtonWPAClicked { get; set; }
        public ICommand ButtonWEPClicked { get; set; }
        public ICommand ButtonNoneClicked { get; set; }
        public INavigation Navigation { get; set; }

        [Obsolete]
        public WLanViewModel(INavigation navigation)
        {
            culture = new CultureLang();

            if(culture.GetCulture() == "de")
            {
                ButtonCulture = "QR-Code generieren";
                TitleCulture = "Wlan QR-Code generieren";
                PasswordCulture = "Passwort";
            }
            else
            {
                ButtonCulture = "Generate QR-Code";
                TitleCulture = "Generate Wlan QR-Code";
                PasswordCulture = "Password";
            }
           
             
            
                ReadOnly = "True";
            WpaWep = "WPA/WPA2";
            this.Navigation = navigation;
            wlanKey = "WPA/WPA2";
            ButtonWPAClicked = new Command(WPA_Clicked);
            ButtonWEPClicked = new Command(WEP_Clicked);
            ButtonNoneClicked = new Command(None_Clicked);
            ButtonGenerateClicked = new Command(GetWlanConnectionCode);
           
        }
        public string ButtonCulture
        {
            get => buttonCulture;
            set => SetProperty(ref buttonCulture, value);
        }
        public string PasswordCulture
        {
            get => passwordCulture;
            set => SetProperty(ref passwordCulture, value);
        }
        public string TitleCulture
        {
            get => titleCulture;
            set => SetProperty(ref titleCulture, value);
        }
        public string GenerateText
        {
            get => generate;
            set => SetProperty(ref generate, value);
        }
        public string WpaWep
        {
            get => wpa;
            set => SetProperty(ref wpa, value);
        }
        public string SSIDText
        {
            get => ssid;
            set => SetProperty(ref ssid, value);
        }
      
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public string ReadOnly
        {
            get => readOnly;
            set => SetProperty(ref readOnly, value);
        }
        void WPA_Clicked()
        {
            ReadOnly = "False";
           WpaWep = "";
            wlanKey = "WPA/WPA2";
            WpaWep = wlanKey;
            ReadOnly = "True";
        }
        void WEP_Clicked()
        {
            ReadOnly = "False";
            WpaWep = "";
            wlanKey = "WEP";
            WpaWep = wlanKey;
            ReadOnly = "True";
        }
        void None_Clicked()
        {
            ReadOnly = "False";
            WpaWep = "";
            wlanKey = "none";
            WpaWep = wlanKey;
            ReadOnly = "True";
        }

        [Obsolete]
        async void GetWlanConnectionCode()

        {
            bool isContact = false;
            bool isEvent = false;
            bool isPhoneNumber = false;
            bool isEmail = false;

                if (wlanKey == "WPA/WPA2")
                {
                 GenerateText = "WIFI:S:" + SSIDText + ";T:WPA;P:" + Password + ";";
                }
                
                if (wlanKey == "WEP")
                {
                    GenerateText = "WIFI:S:" + SSIDText + ";T:WEP;P:" + Password + ";";
                }
                
                if (wlanKey == "none")
                {
                    GenerateText = "WIFI:S:" + SSIDText + ";T:;P:" + Password + ";";
                }

            await Navigation.PushAsync(new QRGeneratorPage(GenerateText,isContact,isEvent,isPhoneNumber,isEmail));
        }
    } 
}
