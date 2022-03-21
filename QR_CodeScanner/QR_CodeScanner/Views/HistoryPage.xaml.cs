
using Android.App;
using Android.Widget;
using QR_CodeScanner.Model;
using QR_CodeScanner.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Windows.Storage;

namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        QRhistoryModel history;
        Color background, frame;
        [Obsolete]
        public HistoryPage(string qrText, string eventQR, bool course, Color background, Color frame)
        {
            InitializeComponent();
            history = new QRhistoryModel();
            DataBaseresult();
            grid.BackgroundColor = background;
            this.background = background;
            this.BackgroundColor = background;
            this.frame = frame;
            if (qrText != null)
            {
                if (course == true)
                    AddToDB(qrText, eventQR);
            }


        }


        private void DataBaseresult()
        {
            if (App.Database1.GetQRcodeAsync().Result.Count == 0)
            {
                toolItem.IsEnabled = false;
                string txt = string.Empty;
                if (CultureLanguage.GetCulture() == "de")
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

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database1.GetQRcodeAsync();
        }

        private async void AddToDB(string qrTxt, string ev)
        {
            var db = App.Database1;
            if (!string.IsNullOrWhiteSpace(qrTxt) && !string.IsNullOrWhiteSpace(ev))
            {

                await db.SaveQRcodeAsync(new Model.QRhistoryModel
                {

                    QRText = qrTxt,
                    Event = ev,
                    Date = DateTime.Now,
                });



                collectionView.ItemsSource = await db.GetQRcodeAsync();
            }
        }

        [Obsolete]
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string qrtxt = (e.CurrentSelection.FirstOrDefault() as QRhistoryModel)?.QRText;
            string eve = (e.CurrentSelection.FirstOrDefault() as QRhistoryModel)?.Event;

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
                    website = true;
                    break;
            }
            if (text == true)
            {
                OpenNewGenerator(qrtxt, false, false, false, false, false, false, false, false, false, number, true);
            }
            else
                //wenn hier generator geöffnet wird true
                OpenNewGenerator(qrtxt, wlan, website, contact, eventY, phoneNR, email, sms, barcode, browser, number, true);
        }

        [Obsolete]
        private async void OpenNewGenerator(string qrtxtX, bool wlanX, bool websiteX, bool contactX, bool eventX, bool phoneNRX, bool emailX, bool smsX, bool barcodeX, bool browserX, string numberX, bool fromProgress)
        {
            QRGeneratorPage qrGVM = new QRGeneratorPage(qrtxtX, wlanX, websiteX, contactX, eventX, phoneNRX, emailX, smsX, barcodeX, browserX, numberX, true, background, frame);
            await Navigation.PushAsync(qrGVM);
        }

        [Obsolete]
        private async void clearItem_Clicked(object sender, EventArgs e)
        {
            var db = App.Database1;
            var item = (sender as Xamarin.Forms.Button).Text;
            int id = Convert.ToInt32(item);
            string title = string.Empty;
            string yes = string.Empty;
            string no = string.Empty;

            if (CultureLanguage.GetCulture() == "de")
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
                await db.DeleteItemAsync(id);
                collectionView.ItemsSource = await db.GetQRcodeAsync();
                DataBaseresult();
            }


        }



        [Obsolete]
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            string title = string.Empty;
            string yes = string.Empty;
            string no = string.Empty;
            var db = App.Database1;
            if (CultureLanguage.GetCulture() == "de")
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
                await db.DeleteAllItems<QRhistoryModel>();
                collectionView.ItemsSource = await db.GetQRcodeAsync();
                DataBaseresult();
            }


        }
    }
}