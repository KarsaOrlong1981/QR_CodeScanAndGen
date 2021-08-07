using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using QR_CodeScanner.ViewModel;
using QR_CodeScanner.Views;
using Xamarin.Forms;


namespace QR_CodeScanner.ViewModel
{
    public class WLanViewModel : BaseViewModel
    {
        string ssid;
        string wpa;
        string password;
        string wlanKey;
        string generate;
        string readOnly;
        public ICommand ButtonGenerateClicked { get; set; }
        public ICommand ButtonWPAClicked { get; set; }
        public ICommand ButtonWEPClicked { get; set; }
        public ICommand ButtonNoneClicked { get; set; }
        public INavigation Navigation { get; set; }
        public WLanViewModel(INavigation navigation)
        {
            ReadOnly = "True";
            WpaWep = "WPA/WPA2";
            this.Navigation = navigation;
            wlanKey = "WPA/WPA2";
            ButtonWPAClicked = new Command(WPA_Clicked);
            ButtonWEPClicked = new Command(WEP_Clicked);
            ButtonNoneClicked = new Command(None_Clicked);
            ButtonGenerateClicked = new Command(GetWlanConnectionCode);
           
        }
        public string GeneratText
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
            wlanKey = "";
            WpaWep = wlanKey;
            ReadOnly = "True";
        }

        async void GetWlanConnectionCode()

        {


                if (wlanKey == "WPA/WPA2")
                {
                 GeneratText = "WIFI:S:" + SSIDText + ";T:WPA;P:" + Password + ";";
                }
                if (wlanKey == "WEP")
                {
                    GeneratText = "WIFI:S:" + SSIDText + ";T:WEP;P:" + Password + ";";
                }
                if (wlanKey == "none")
                {
                    GeneratText = "WIFI:S:" + SSIDText + ";T:;P:" + Password + ";";
                }

            await Navigation.PushAsync(new QRGeneratorPage(GeneratText));
        }
    } 
}
