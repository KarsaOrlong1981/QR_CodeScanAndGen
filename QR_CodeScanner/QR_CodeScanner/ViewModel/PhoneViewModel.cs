using System;
using System.Collections.Generic;
using System.Text;
using QR_CodeScanner.Views;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace QR_CodeScanner.ViewModel
{
   
    public class PhoneViewModel : BaseViewModel
    {
        string phoneNumber;
        public INavigation Navigation { get; set; }
        public ICommand ButtonGeneratorPageClicked { get; set; }

        [Obsolete]
        public PhoneViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            ButtonGeneratorPageClicked = new Command(async () => await CallQRGeneratorPage());
        }
        [Obsolete]
        public async Task CallQRGeneratorPage()
        {
            bool isContact = false;
            bool isEvent = false;
            bool isPhoneNumber = true;
            bool isEmail = false;
            await Navigation.PushAsync(new QRGeneratorPage(PhoneNumber, isContact, isEvent,isPhoneNumber,isEmail));
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }

    }
}
