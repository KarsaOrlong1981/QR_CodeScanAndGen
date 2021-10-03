
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
        QRhistory history;
        CultureLang culture;
        
        [Obsolete]
        public HistoryPage(string qrText,string eventQR,bool course)
        {
            InitializeComponent();
            culture = new CultureLang();
            history = new QRhistory();
            DataBaseresult();
           
            if(qrText != null)
            {
               if(course == true)
                AddToDB(qrText,eventQR);
            }
            
            
        }
     

       private void DataBaseresult()
       {
            if (App.Database1.GetQRcodeAsync().Result.Count == 0)
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
       
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database1.GetQRcodeAsync();
        }

        private async void AddToDB(string qrTxt,string ev)
        {
            if (!string.IsNullOrWhiteSpace(qrTxt) && !string.IsNullOrWhiteSpace(ev))
            {
                
                await App.Database1.SaveQRcodeAsync(new Model.QRhistory
                {
                    
                    QRText = qrTxt ,
                    Event = ev,
                    Date = DateTime.Now ,
                });

                
               
                collectionView.ItemsSource = await App.Database1.GetQRcodeAsync();
            }
        }

        [Obsolete]
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string qrtxt = (e.CurrentSelection.FirstOrDefault() as QRhistory)?.QRText;
            string eve = (e.CurrentSelection.FirstOrDefault() as QRhistory)?.Event;
           
            string number = string.Empty;
            bool text = false;
            bool wlan = false;
            bool website = false;
            bool contact = false;
            bool eventY = false;
            bool phoneNR = false;
            bool email = false;
            bool sms = false;
            bool food = false;
            bool browser = false;
            
            
            switch (eve)
            {
                case "Text": text = true;
                    break;
                case "Wlan": wlan = true;
                    break;
                case "Website": website = true;
                    break;
                case "Contact": contact = true;
                    break;
                case "Event": eventY = true;
                    break;
                case "Phonenumber": phoneNR = true;
                    break;
                case "Email": email = true;
                    break;
                case "SMS": sms = true;
                    string[] messageAndNumber = qrtxt.Split(':');
                    qrtxt = messageAndNumber[1];
                    number = messageAndNumber[2];
                    break;
                case "Food": food = true;
                    break;
                    case "Browser": website = true;
                    break;
            }
            if(text == true)
            {
                OpenNewGenerator(qrtxt, false, false, false,false, false, false, false, false, false, number, true);
            }
            else
            //wenn hier generator geöffnet wird true
            OpenNewGenerator(qrtxt,wlan,website,contact,eventY,phoneNR,email,sms,food,browser,number,true);
           // collectionView.SelectionChanged -= this.CollectionView_SelectionChanged;
            //collectionView.SelectedItem = null;
           // collectionView.SelectionChanged += this.CollectionView_SelectionChanged;
        }

        [Obsolete]
        private async void OpenNewGenerator(string qrtxtX,bool wlanX, bool websiteX,bool contactX, bool eventX, bool phoneNRX,bool emailX, bool smsX, bool foodX,bool browserX, string numberX,bool fromProgress)
        {
            QRGeneratorPage qrGVM = new QRGeneratorPage(qrtxtX,wlanX,websiteX, contactX, eventX, phoneNRX, emailX, smsX, foodX, browserX, numberX,true);
            await Navigation.PushAsync(qrGVM);
        }

        [Obsolete]
        private async void clearItem_Clicked(object sender, EventArgs e)
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
                await App.Database1.DeleteItemAsync(id);
                collectionView.ItemsSource = await App.Database1.GetQRcodeAsync();
                DataBaseresult();
            }
           
          
        }

       

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }

        [Obsolete]
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
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
                    await App.Database1.DeleteAllItems<QRhistory>();
                    collectionView.ItemsSource = await App.Database1.GetQRcodeAsync();
                    DataBaseresult();
                }
            
           
        }
    }
}