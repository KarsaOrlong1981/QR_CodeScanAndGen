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
        public QRGeneratorPage(string qrCodeText,bool isContact,bool isEvent,bool isPhoneNumber,bool isEmail,bool isSMS, bool isFood, bool isWebsite,string phoneNumber)
        {
            InitializeComponent();

            BindingContext = new QRGeneratorViewModel(qrCodeText, isContact,isEvent,isPhoneNumber,isEmail,isSMS,isFood,isWebsite,phoneNumber);              
        }

      
    }
}