using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

using QR_CodeScanner.ViewModel;
using QR_CodeScanner.Views;
using Xamarin.Essentials;
using System.Windows.Input;

namespace QR_CodeScanner.ViewModel
{
    public class QRGeneratorViewModel : BaseViewModel
    {
        string qrCodeTxt;
        public ICommand ButtonShareClicked { get; set; }
        public QRGeneratorViewModel(string qrTxt)
        {
            qrCodeTxt = qrTxt;
            ButtonShareClicked = new Command(ShareQR);
        }
        public string QRCodeText
        {
            get => qrCodeTxt;
            set => SetProperty(ref qrCodeTxt, value);
        }
        async void ShareQR()
        {

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = QRCodeText,
                Title = "Share!"
            });

        }
        
    }
}
