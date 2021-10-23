﻿using System;
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
using QR_CodeScanner.Model;
using Android.Net.Wifi;
using Android.Media.Midi;

namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ScannerPage : ContentPage
    {
        CultureLang culture;
        public ScannerPage()
        {
            InitializeComponent();
            culture = new CultureLang();
        }
        //If the Scanner recognizes an QR-Code
        [Obsolete]
        public void scanView_OnScanResult(Result result)
        {


            Device.BeginInvokeOnMainThread(async () =>
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


                            BooleanCallResult(result.Text, false, false, true, false, false, false, false, false, false, string.Empty);
                        }
                        //To recognizes an VCalendar and read Vcalendar
                        if (resultString.Substring(0, 11) == "BEGIN:VCALE")
                        {

                            BooleanCallResult(result.Text, false, false, false, true, false, false, false, false, false, string.Empty);

                        }


                    }
                    else
                    {


                        //here i can say that is Text
                        BooleanCallResult(result.Text, false, false, false, false, false, false, false, false, false, string.Empty);
                    }

                    if (resultString.Length >= 11)
                    {
                        if (!(resultString.Substring(0, 11) == "BEGIN:VCARD") && (!(resultString.Substring(0, 11) == "BEGIN:VCALE")))
                        {
                            if (resultString.Length >= 4)
                            //open website with Browser or sms or wlan
                            {
                                if (resultString.Substring(0, 4) == "http" || resultString.Substring(0, 4) == "smst" || resultString.Substring(0, 4) == "WIFI")
                                {
                                    if (resultString.Substring(0, 4) == "http")
                                    {
                                        try
                                        {
                                            ScanHistory scanned = new ScanHistory(resultString, "Browser", true);
                                            await OpenBrowser(resultString);

                                        }
                                        catch
                                        {
                                            var activity = Forms.Context as Activity;
                                            if (culture.GetCulture() == "de")

                                                Toast.MakeText(activity, "Website kann nicht geladen werden.", ToastLength.Long).Show();

                                            else

                                                Toast.MakeText(activity, "Website not found.", ToastLength.Long).Show();
                                        }
                                    }
                                    if (resultString.Substring(0, 4) == "smst")
                                    {
                                        ScanHistory scanned = new ScanHistory(resultString, "SMS", true);
                                        string[] messageAndNumber = resultString.Split(':');
                                        await SendSms(messageAndNumber[2], messageAndNumber[1]);
                                    }
                                    if (resultString.Substring(0, 4) == "WIFI")
                                    {
                                        BooleanCallResult(result.Text, true, false, false, false, false, false, false, false, false, string.Empty);
                                    }
                                }
                                else
                                    BooleanCallResult(result.Text, false, false, false, false, false, false, false, false, false, string.Empty);//Here ican say that is Text
                            }
                            else
                                BooleanCallResult(result.Text, false, false, false, false, false, false, false, false, false, string.Empty);//Here ican say that is Text

                        }
                    }
                }
                else
                {
                    //hére i can say its an Phonenumber
                    BooleanCallResult(result.Text, false, false, false, false, true, false, false, false, false, string.Empty);
                }

            });
        }

        [Obsolete]
        void BooleanCallResult(string result, bool isWL, bool isWeb, bool isCon, bool isEv, bool isPho, bool isEmail, bool isSMS, bool isFood, bool isBrowser, string phoneNumber)
        {


            CallResultPageWithConEven(result, isWL, isWeb, isCon, isEv, isPho, isEmail, isSMS, isFood, isBrowser, phoneNumber);
        }

        [Obsolete]
        async void CallResultPageWithConEven(string resultQrCode, bool isWlan, bool isWebsite, bool isContact, bool isEvent, bool isPhonenumber, bool isEmail, bool isSMS, bool isFood, bool isBrowser, string phoneNumber)
        {


            ResultPage call = new ResultPage(resultQrCode, isWlan, isWebsite, isContact, isEvent, isPhonenumber, isEmail, isSMS, isFood, isBrowser, string.Empty, false);
            await Navigation.PushAsync(call);
            scanView.IsScanning = true;
            scanView.IsAnalyzing = true;
        }


        //If Scanner recognizes an Website open Browser
        public async Task OpenBrowser(string uri)
        {
            await Xamarin.Essentials.Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        private void ZXingDefaultOverlay_FlashButtonClicked(Xamarin.Forms.Button sender, EventArgs e)
        {
            scanView.ToggleTorch();
        }

        [Obsolete]
        private async Task SendSms(string messageText, string recipient)
        {
            try
            {
                var message = new SmsMessage(messageText, recipient);
                await Sms.ComposeAsync(message);
            }
            catch
            {
                // Sms is not supported on this device.
                var activity = Forms.Context as Activity;
                if (culture.GetCulture() == "de")

                    Toast.MakeText(activity, "SMS wird auf diesem Gerät nicht unterstützt.", ToastLength.Long).Show();

                else

                    Toast.MakeText(activity, "Sms is not supported on this device.", ToastLength.Long).Show();
            }
        }

    }
}