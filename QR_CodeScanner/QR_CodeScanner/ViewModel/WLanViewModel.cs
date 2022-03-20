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
        Color background, frame;
        public INavigation Navigation { get; set; }
        string ssid;
        string wpa;
        string password, passwordCulture, titleCulture;
        string wlanKey;
        string generate, buttonCulture;
        string readOnly;
        #region ICommands
        public ICommand ButtonGenerateClicked { get; set; }
        public ICommand ButtonWPAClicked { get; set; }
        public ICommand ButtonWEPClicked { get; set; }
        public ICommand ButtonNoneClicked { get; set; }
        #endregion // ICommands
        #region Propertys
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
        #endregion // Propertys
        [Obsolete]
        public WLanViewModel(INavigation navigation, Color background, Color frame)
        {
            this.background = background;
            this.frame = frame;
            if (CultureLanguage.GetCulture() == "de")
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
        #region Command Events
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
        #endregion // Command Events

        [Obsolete]
        async void GetWlanConnectionCode()

        {

            switch (wlanKey)
            {

                case "WPA/WPA2":
                    GenerateText = "WIFI:S:" + SSIDText + ";T:WPA;P:" + Password + ";H:false;;";
                    break;

                case "WEP":
                    GenerateText = "WIFI:S:" + SSIDText + ";T:WEP;P:" + Password + ";H:false;;";
                    break;

                case "none":
                    GenerateText = "WIFI:S:" + SSIDText + ";T:;P:" + Password + ";H:false;;";
                    break;
            }
            await Navigation.PushAsync(new QRGeneratorPage(GenerateText, true, false, false, false, false, false, false, false, false, string.Empty, false, background, frame));
        }
    }
}
