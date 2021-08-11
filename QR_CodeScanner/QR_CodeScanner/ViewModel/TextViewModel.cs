using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using QR_CodeScanner.Views;
using QR_CodeScanner.ViewModel;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace QR_CodeScanner.ViewModel
{
    public class TextViewModel : BaseViewModel 
    {
        string entry;
        public ICommand ButtonGeneratorPageClicked { get; set; }
        public INavigation Navigation { get; set; }

        [Obsolete]
        public TextViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
           
            ButtonGeneratorPageClicked = new Command(async () => await CallQRGeneratorPage());
        }

        [Obsolete]
        public async Task CallQRGeneratorPage()
        {
            bool isContact = false;
            await Navigation.PushAsync(new QRGeneratorPage(EntryText,isContact));
        }
        public string EntryText
        {
            get => entry;
            set => SetProperty(ref entry, value);
        }

    }
}
