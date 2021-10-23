using QR_CodeScanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanHistory : ContentPage
    {
        ScanHistoryModel history;
        CultureLang culture;

        public ScanHistory(string qrText, string eventQR, bool course)
        {
            InitializeComponent();
            culture = new CultureLang();
            history = new ScanHistoryModel();
            DataBaseresult();

            if (qrText != null)
            {
                if (course == true)
                    AddToScanDB(qrText, eventQR);
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database2.GetScanQRcodeAsync();
        }
        private async void AddToScanDB(string qrTxt, string ev)
        {
            if (!string.IsNullOrWhiteSpace(qrTxt) && !string.IsNullOrWhiteSpace(ev))
            {

                await App.Database2.SaveScanQRcodeAsync(new ScanHistoryModel
                {

                    ScanQRText = qrTxt,
                    ScanEvent = ev,
                    ScanDate = DateTime.Now

                });



                collectionView.ItemsSource = await App.Database2.GetScanQRcodeAsync();
            }
        }

        private void DataBaseresult()
        {
            if (App.Database2.GetScanQRcodeAsync().Result.Count == 0)
            {
                toolItem.IsEnabled = false;
                string txt = string.Empty;
                if (culture.GetCulture() == "de")
                {
                    txt = "Kein Verlauf vorhanden.";
                }
                else
                {
                    txt = "No History";
                }
                Label lab = new Label
                {
                    Text = txt,
                    FontSize = 25.0,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    TextColor = Color.Black,
                };
                grid.Children.Add(lab);
            }
        }

        [Obsolete]
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string qrtxt = (e.CurrentSelection.FirstOrDefault() as ScanHistoryModel)?.ScanQRText;
            string eve = (e.CurrentSelection.FirstOrDefault() as ScanHistoryModel)?.ScanEvent;

            string number = string.Empty;
            bool text = false;
            bool wlan = false;
            bool website = false;
            bool contact = false;
            bool eventY = false;
            bool phoneNR = false;
            bool email = false;
            bool sms = false;
            bool barcode = false;
            bool browser = false;


            switch (eve)
            {
                case "Text":
                    text = true;
                    break;
                case "Wlan":
                    wlan = true;
                    break;
                case "Website":
                    website = true;
                    break;
                case "Contact":
                    contact = true;
                    break;
                case "Event":
                    eventY = true;
                    break;
                case "Phonenumber":
                    phoneNR = true;
                    break;
                case "Email":
                    email = true;
                    break;
                case "SMS":
                    sms = true;
                    string[] messageAndNumber = qrtxt.Split(':');
                    qrtxt = messageAndNumber[1];
                    number = messageAndNumber[2];
                    break;
                case "Barcode":
                    barcode = true;
                    break;
                case "Browser":
                    browser = true;
                    break;
            }
            if (text == true)
            {
                OpenNewResult(qrtxt, false, false, false, false, false, false, false, false, false, number, true);
            }
            else
                //wenn hier generator geöffnet wird true
                OpenNewResult(qrtxt, wlan, website, contact, eventY, phoneNR, email, sms, barcode, browser, number, true);
        }

        [Obsolete]
        private async void OpenNewResult(string qrtxtX, bool wlanX, bool websiteX, bool contactX, bool eventX, bool phoneNRX, bool emailX, bool smsX, bool barcodeX, bool browserX, string numberX, bool fromProgress)
        {
            ResultPage qrGVM = new ResultPage(qrtxtX, wlanX, websiteX, contactX, eventX, phoneNRX, emailX, smsX, barcodeX, browserX, numberX, true);
            await Navigation.PushAsync(qrGVM);
        }

        private async void toolItem_Clicked(object sender, EventArgs e)
        {
            string title = string.Empty;
            string yes = string.Empty;
            string no = string.Empty;

            if (culture.GetCulture() == "de")
            {
                title = "Wollen sie wirklich den gesamten Verlauf löschen?";
                yes = "Ja";
                no = "Nein";
            }
            else
            {
                title = "Do you really want to delete the entire history?";
                yes = "Yes";
                no = "No";
            }


            string result = await DisplayActionSheet(title, null, null, yes, no);
            if (result == yes)
            {
                await App.Database2.DeleteAllScanItems<ScanHistoryModel>();
                collectionView.ItemsSource = await App.Database2.GetScanQRcodeAsync();
                DataBaseresult();
            }
        }

        private async void clearItem_ClickedAsync(object sender, EventArgs e)
        {
            var item = (sender as Xamarin.Forms.Button).Text;
            int id = Convert.ToInt32(item);
            string title = string.Empty;
            string yes = string.Empty;
            string no = string.Empty;

            if (culture.GetCulture() == "de")
            {
                title = "Wollen sie diesen QR-Code wirklich löschen?";
                yes = "Ja";
                no = "Nein";
            }
            else
            {
                title = "Do you really want to delete this QR-Code?";
                yes = "Yes";
                no = "No";
            }


            string result = await DisplayActionSheet(title, null, null, yes, no);
            if (result == yes)
            {
                await App.Database2.DeleteScanItemAsync(id);
                collectionView.ItemsSource = await App.Database2.GetScanQRcodeAsync();
                DataBaseresult();
            }

        }
    }
}