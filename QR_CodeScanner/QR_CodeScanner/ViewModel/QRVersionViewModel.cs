using QR_CodeScanner.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using QR_CodeScanner.ViewModel;

namespace QR_CodeScanner.ViewModel
{
    public class QRVersionViewModel : BaseViewModel 
    {
        public INavigation Navigation { get; set; }
        public ICommand ButtonTextClicked { get; set; }

        public ICommand ButtonWebsiteClicked { get; set; }
        public ICommand ButtonWLanClicked { get; set; }
        public ICommand ButtonContactClicked { get; set; }
        public QRVersionViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            ButtonWebsiteClicked = new Command(GotoWebsitepage);
            ButtonTextClicked = new Command(GotoTextpage);
            ButtonWLanClicked = new Command(GotoWlanpage);
            ButtonContactClicked = new Command(GotoContactPage);
        }
        public async Task CallTextPage()
        {

            await Navigation.PushAsync(new TextPage());
        }
        public async Task CallWebsitePage()
        {

            await Navigation.PushAsync(new WebsitePage());
        }
        public async Task CallWLanPage()
        {

            await Navigation.PushAsync(new WlanPage());
        }
        public async Task CallContactPage()
        {

            await Navigation.PushAsync(new ContactPage());
        }
        async void GotoWebsitepage()
        {
          await CallWebsitePage();
        }
        async void GotoTextpage()
        {
            await CallTextPage();
        }
        async void GotoWlanpage()
        {
            await CallWLanPage();
        }
        async void GotoContactPage()
        {
            await CallContactPage();
        }
    }
}
