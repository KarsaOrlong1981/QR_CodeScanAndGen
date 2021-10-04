using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using QR_CodeScanner.ViewModel;
using Xamarin.Forms.Internals;

namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRGeneratorPage : ContentPage
    {


        [Obsolete]
        public QRGeneratorPage(string qrCodeText, bool isWlan, bool isWebsite, bool isContact, bool isEvent, bool isPhoneNumber, bool isEmail, bool isSMS, bool isFood, bool isBrowser, string phoneNumber, bool fromProgress)
        {
            InitializeComponent();

            BindingContext = new QRGeneratorViewModel(qrCodeText, isWlan, isWebsite, isContact, isEvent, isPhoneNumber, isEmail, isSMS, isFood, isBrowser, phoneNumber, fromProgress);
        }

    }
}