using QR_CodeScanner.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QR_CodeScanner.ViewModel
{
    public class FoodViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand ButtonGeneratorPageClicked { get; set; }

        string add;

        [Obsolete]
        public FoodViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            ButtonGeneratorPageClicked = new Command(async () => await CallQRGeneratorPage());
        }

        [Obsolete]
        private async Task CallQRGeneratorPage()
        {
            bool isContact = false;
            bool isEvent = false;
            bool isPhoneNumber = false;
            bool isEmail = true;
            await Navigation.PushAsync(new QRGeneratorPage(ADD, false, false, false, false, false, false, false, true, false, string.Empty, false));
        }

        public string ADD { get => add; set => SetProperty(ref add, value); }

    }
}
