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
           
            await Navigation.PushAsync(new QRGeneratorPage(PhoneNumber,false,false, false, false,true,false,false,false,false,string.Empty,false));
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }

    }
}
