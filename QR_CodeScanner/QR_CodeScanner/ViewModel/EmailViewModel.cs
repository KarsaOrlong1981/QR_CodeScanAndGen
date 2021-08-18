﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QR_CodeScanner.Views;
using Xamarin.Forms;

namespace QR_CodeScanner.ViewModel
{
    public class EmailViewModel : BaseViewModel
    {
        string email;
        public INavigation Navigation { get; set; }
        public ICommand ButtonGeneratorPageClicked { get; set; }

        [Obsolete]
        public EmailViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            ButtonGeneratorPageClicked = new Command(async () => await CallQRGeneratorPage());
        }
        [Obsolete]
        public async Task CallQRGeneratorPage()
        {
            bool isContact = false;
            bool isEvent = false;
            bool isPhoneNumber = false;
            bool isEmail = true;
            await Navigation.PushAsync(new QRGeneratorPage(EmailADD, isContact, isEvent, isPhoneNumber, isEmail));
        }
        public string EmailADD
        {
            get => email ;
            set => SetProperty(ref email , value);
        }
    }
}