using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using Xamarin.Essentials;
using Android.Content;
using Android.Provider;
using Android.App;
using Android.Widget;
using Result = ZXing.Result;





namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   
    public partial class ScannerPage : ContentPage
    {

        private bool isContactS, isEventS, isPhoneNrS, isEmailS;
        public ScannerPage()
        {
            InitializeComponent();

            isEventS = false;
            isPhoneNrS = false;
            isEmailS = false;
            isContactS = false;
        }
        //If the Scanner recognizes an QR-Code
        [Obsolete]
        public void scanView_OnScanResult(Result result)
        {
           

            Device.BeginInvokeOnMainThread(() =>
            {
                scanView.IsScanning = false;
                scanView.IsAnalyzing = false;
                Navigation.RemovePage(this);
                string resultString = result.Text;


                if (!resultString.All(Char.IsDigit))
                {
                    if (resultString.Length >= 11)
                    {

                        //To recognize an VCard and read the Vcard
                        if (resultString.Substring(0, 11) == "BEGIN:VCARD")
                        {


                            BooleanCallResult(result.Text, false, true, false, false);
                        }
                        //To recognizes an VCalendar and read Vcalendar
                        if (resultString.Substring(0, 11) == "BEGIN:VCALE")
                        {

                            BooleanCallResult(result.Text, true, false, false, false);
                            
                        }
                        

                    }
                    else
                    {
                        //here i can say that is Text
                        BooleanCallResult(result.Text, false, false, false, false);
                    }

                    if (resultString.Length >= 11)
                    {
                        if (!(resultString.Substring(0, 11) == "BEGIN:VCARD") && (!(resultString.Substring(0,11) == "BEGIN:VCALE")))
                        {
                            BooleanCallResult(result.Text, false, false, false, false);//Here ican say that is Text
                        }
                    }




                }
                else
                {
                    BooleanCallResult(result.Text, false, false, true, false);
                }
                  



               









                /*try
                {
                    await OpenBrowser(result.Text);
                }
                catch
                {

                }*/



            });
        }

        [Obsolete]
        void BooleanCallResult(string result,bool isEv, bool isCon, bool isPho, bool isEma)
        {
            isEventS = isEv;
            isContactS = isCon;
            isPhoneNrS = isPho;
            isEmailS = isEma;

            CallResultPageWithConEven(result, isContactS, isEventS, isPhoneNrS, isEmailS);
        }

        [Obsolete]
        async void CallResultPageWithConEven(string resultQrCode,bool isContact,bool isEvent,bool isPhonenumber, bool isEmail)
        {
           
           
            ResultPage call = new ResultPage(resultQrCode,isContact,isEvent,isPhonenumber,isEmail);
            await Navigation.PushAsync(call);
            scanView.IsScanning = true;
            scanView.IsAnalyzing = true;
        }

     
        //If Scanner recognizes an Website open Browser
        public async Task OpenBrowser(string uri)
        {
            try
            {
                await Xamarin.Essentials.Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch(Exception)
            {
               
            }

                
        }
       
        private void ZXingDefaultOverlay_FlashButtonClicked(Xamarin.Forms.Button sender, EventArgs e)
        {
            scanView.ToggleTorch();
        }

       

        
        
       
       

     
    }
}