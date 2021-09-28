﻿using QR_CodeScanner.Views;
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
        public ICommand ButtonTextClicked { get; set; }

        public ICommand ButtonWebsiteClicked { get; set; }
        public ICommand ButtonWLanClicked { get; set; }
        public ICommand ButtonContactClicked { get; set; }
        public ICommand ButtonEventClicked { get; set; }
        public ICommand ButtonPhoneClicked { get; set; }
        public ICommand ButtonEmailClicked { get; set; }
        public ICommand ButtonSmSClicked { get; set; }
        public ICommand ButtonFoodClicked { get; set; }

        [Obsolete]
        public QRVersionViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            ButtonWebsiteClicked = new Command(GotoWebsitePage);
            ButtonTextClicked = new Command(GotoTextPage);
            ButtonWLanClicked = new Command(GotoWlanPage);
            ButtonContactClicked = new Command(GotoContactPage);
            ButtonEventClicked = new Command(GotoEventPage);
            ButtonPhoneClicked = new Command(GotoPhonePage);
            ButtonEmailClicked = new Command(GotoEmailPage);
            ButtonSmSClicked = new Command(GotoSmSPage);
            ButtonFoodClicked = new Command(GotoFoodPage);
        }

        [Obsolete]
        public async Task CallFoodPage()
        {
            await Navigation.PushAsync(new FoodPage());
        }
        public async Task CallSmSPage()
        {
            await Navigation.PushAsync(new SMSPage());
        }

        [Obsolete]
        public async Task CallPhonePage()
        {

            await Navigation.PushAsync(new PhonePage());
        }

        [Obsolete]
        public async Task CallEmailPage()
        {

            await Navigation.PushAsync(new EmailPage());
        }

        [Obsolete]
        public async Task CallEventPage()
        {
            
            await Navigation.PushAsync(new EventPage());
        }

        [Obsolete]
        public async Task CallTextPage()
        {

            await Navigation.PushAsync(new TextPage());
        }

        [Obsolete]
        public async Task CallWebsitePage()
        {

            await Navigation.PushAsync(new WebsitePage());
        }

        [Obsolete]
        public async Task CallWLanPage()
        {

            await Navigation.PushAsync(new WlanPage());
        }

        [Obsolete]
        public async Task CallContactPage()
        {

            await Navigation.PushAsync(new ContactPage());
        }

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
        private async void GotoFoodPage()
        {
            await CallFoodPage();
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
        private async void GotoSmSPage()
        {
            await CallSmSPage();
        }
    }
}
