using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QR_CodeScanner.ViewModel;
using QR_CodeScanner.Views;
using Xamarin.Forms;

namespace QR_CodeScanner.ViewModel
{
    public class ContactViewModel : BaseViewModel
    {
        string compName;
        string titel;
        string company;
        string email;
        string phone;
        string adress;
        string website;

        public INavigation Navigation { get; set; }

        public ICommand ButtonGenerateClicked { get; set; }

        [Obsolete]
        public ContactViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            ButtonGenerateClicked = new Command(async () => await CallQRGeneratorPage());

        }

        [Obsolete]
        async Task CallQRGeneratorPage()
        {
            await Navigation.PushAsync(new QRGeneratorPage(GetContact(), false, false, true, false, false, false, false, false, false, string.Empty, false));
        }
        string GetContact()
        {
            string vCard;
            vCard = "BEGIN:VCARD\nVERSION:3.0\nN:" + CompName + "\nORG:" + Company + "\nTITLE:" + Titel + "\nTEL:" + Phone +
                    "\nURL:" + Website + "\nEMAIL:" + Email + "\nADR:" + Adress + "\nEND:VCARD";
            return vCard;
        }
        public string CompName
        {
            get => compName;
            set => SetProperty(ref compName, value);
        }
        public string Titel
        {
            get => titel;
            set => SetProperty(ref titel, value);
        }
        public string Company
        {
            get => company;
            set => SetProperty(ref company, value);
        }
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }
        public string Adress
        {
            get => adress;
            set => SetProperty(ref adress, value);
        }
        public string Website
        {
            get => website;
            set => SetProperty(ref website, value);
        }
    }
}
