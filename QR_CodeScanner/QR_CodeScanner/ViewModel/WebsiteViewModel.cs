using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using QR_CodeScanner.Views;
using Xamarin.Forms;

namespace QR_CodeScanner.ViewModel
{
    public class WebsiteViewModel : BaseViewModel 
    {
        string entry;
        public ICommand ButtonHTTPSClicked { get; set; }
        public ICommand ButtonHTTPClicked { get; set; }
        public ICommand ButtonWWWClicked { get; set; }
        public ICommand ButtonCOMClicked { get; set; }
        public ICommand ButtonDEClicked { get; set; }
        public ICommand ButtonGeneratorPageClicked { get; set; }
        public INavigation Navigation { get; set; }

        [Obsolete]
        public WebsiteViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            ButtonGeneratorPageClicked = new Command(async () => await CallQRGeneratorPage());
            ButtonHTTPSClicked = new Command(HTTPS_Clicked);
            ButtonHTTPClicked = new Command(HTTP_Clicked);
            ButtonWWWClicked = new Command(WWW_Clicked);
            ButtonCOMClicked = new Command(COM_Clicked);
            ButtonDEClicked = new Command(DE_Clicked);
           
        }

        [Obsolete]
        public async Task CallQRGeneratorPage()
        {
            bool isContact = false;
            bool isEvent = false;
            bool isPhoneNumber = false;
            bool isEmail = false;
            await Navigation.PushAsync(new QRGeneratorPage(EntryText,isContact,isEvent,isPhoneNumber,isEmail));
        }
        public string EntryText
        {
            get => entry;
            set => SetProperty(ref entry, value);
        }
        void HTTPS_Clicked()
        {
            EntryText = "";
            EntryText = "https://";
        }
        void HTTP_Clicked()
        {
            EntryText = "";
            EntryText = "http://";
        }
        void WWW_Clicked()
        {
          
            EntryText += "www.";
        }
        void COM_Clicked()
        {
            
            EntryText += ".com";
        }
        void DE_Clicked()
        {
            
            EntryText += ".de";
        }
       
    }
}
