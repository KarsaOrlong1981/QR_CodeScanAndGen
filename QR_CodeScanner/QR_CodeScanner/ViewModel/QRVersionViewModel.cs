using QR_CodeScanner.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using QR_CodeScanner.ViewModel;
using Android.Content;

namespace QR_CodeScanner.ViewModel
{
    public class QRVersionViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        #region ICommand
        public ICommand ButtonTextClicked { get; set; }
        public ICommand ButtonWebsiteClicked { get; set; }
        public ICommand ButtonWLanClicked { get; set; }
        public ICommand ButtonContactClicked { get; set; }
        public ICommand ButtonEventClicked { get; set; }
        public ICommand ButtonPhoneClicked { get; set; }
        public ICommand ButtonEmailClicked { get; set; }
        public ICommand ButtonSmSClicked { get; set; }
        #endregion //ICommand
        #region DesignColor
        Color background, button, txt, frame, border;
        public Color Background
        {
            get => background;
            set => SetProperty(ref background, value);
        }
        public Color Button
        {
            get => button;
            set => SetProperty(ref button, value);
        }
        public Color Txt
        {
            get => txt;
            set => SetProperty(ref txt, value);
        }
        public Color Frame
        {
            get => frame;
            set => SetProperty(ref frame, value);
        }
        public Color Border
        {
            get => border;
            set => SetProperty(ref border, value);
        }
        #endregion // DesignColor
        [Obsolete]
        public QRVersionViewModel(INavigation navigation, Color background, Color button, Color txt, Color frame, Color border)
        {
            this.Navigation = navigation;
            Background = background;
            Button = button;
            Txt = txt;
            Frame = frame;
            Border = border;
            ButtonWebsiteClicked = new Command(GotoWebsitePage);
            ButtonTextClicked = new Command(GotoTextPage);
            ButtonWLanClicked = new Command(GotoWlanPage);
            ButtonContactClicked = new Command(GotoContactPage);
            ButtonEventClicked = new Command(GotoEventPage);
            ButtonPhoneClicked = new Command(GotoPhonePage);
            ButtonEmailClicked = new Command(GotoEmailPage);
            ButtonSmSClicked = new Command(GotoSmSPage);
        }
        #region Async Tasks CallPages
        [Obsolete]
        public async Task CallSmSPage()
        {
            await Navigation.PushAsync(new SMSPage(Background, Button, Txt, Frame, Border));
        }

        [Obsolete]
        public async Task CallPhonePage()
        {

            await Navigation.PushAsync(new PhonePage(Background, Button, Txt, Frame, Border));
        }

        [Obsolete]
        public async Task CallEmailPage()
        {

            await Navigation.PushAsync(new EmailPage(Background, Button, Txt, Frame, Border));
        }

        [Obsolete]
        public async Task CallEventPage()
        {
            await Navigation.PushAsync(new EventPage(Background, Button, Txt, Frame, Border));
        }

        [Obsolete]
        public async Task CallTextPage()
        {
            await Navigation.PushAsync(new TextPage(Background, Button, Txt, Frame, Border));
        }

        [Obsolete]
        public async Task CallWebsitePage()
        {
            await Navigation.PushAsync(new WebsitePage(Background, Button, Txt, Frame, Border));
        }

        [Obsolete]
        public async Task CallWLanPage()
        {
            await Navigation.PushAsync(new WlanPage(Background, Button, Txt, Frame, Border));
        }

        [Obsolete]
        public async Task CallContactPage()
        {
            await Navigation.PushAsync(new ContactPage(Background, Button, Txt, Frame, Border));
        }
        #endregion //CallPages
        #region CommandFuctions

        [Obsolete]
        private async void GotoWebsitePage()
        {
            await CallWebsitePage();
        }
        [Obsolete]
        private async void GotoTextPage()
        {
            await CallTextPage();
        }
        [Obsolete]
        private async void GotoWlanPage()
        {
            await CallWLanPage();
        }

        [Obsolete]
        private async void GotoContactPage()
        {
            await CallContactPage();
        }

        [Obsolete]
        private async void GotoEventPage()
        {
            await CallEventPage();
        }

        [Obsolete]
        private async void GotoPhonePage()
        {
            await CallPhonePage();
        }

        [Obsolete]
        private async void GotoEmailPage()
        {
            await CallEmailPage();
        }

        [Obsolete]
        private async void GotoSmSPage()
        {
            await CallSmSPage();
        }
        #endregion //CommandFuctions
    }
}
