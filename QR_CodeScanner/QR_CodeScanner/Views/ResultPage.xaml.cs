using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QR_CodeScanner.ViewModel;

namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        [Obsolete]//hier noch die anderen schalter hinzufügen
        //Hier muss die Backround color übergeben werden aber erst wenn alle teile schon farben zugewiesen bekommen haben.
        public ResultPage(string qrCodeText, bool isWlan, bool isWebsite, bool isContact, bool isEvent, bool isPhoneNr, bool isEmail, bool isSMS, bool isFood, bool isBrowser, string phoneNumber, bool fromScanHistory, Color background)
        {
            InitializeComponent();
            BindingContext = new ResultViewModel(qrCodeText, isWlan, isWebsite, isContact, isEvent, isPhoneNr, isEmail, isSMS, isFood, isBrowser, string.Empty, fromScanHistory, background);
        }

    }
}