using QR_CodeScanner.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QR_CodeScanner.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public ICommand ButtonGeneratorClicked { get; set; }
        public ICommand ButtonInfoClicked { get; set; }
        public ICommand ButtonProgressClicked { get; set; }
        public ICommand ButtonScannerClicked { get; set; }

        [Obsolete]
        public MainViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            ButtonGeneratorClicked = new Command(async () => await CallQRVersionPage());
            ButtonScannerClicked = new Command(async () => await CallScannerPage());
            ButtonProgressClicked = new Command(async () => await CallProgressPage());
        }

        private async Task CallProgressPage()
        {
            await Navigation.PushAsync(new ProgressPage(null));
        }

        [Obsolete]
        private async Task CallQRVersionPage()
        {
            
            await Navigation.PushAsync(new QRVersionPage());
        }
        private async Task CallScannerPage()
        {

            

            await Navigation.PushAsync(new ScannerPage());
        }




       

    }
}
