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
        [Obsolete]
        public ResultPage(string qrCodeText,bool isContact,bool isEvent, bool isPhoneNr, bool isEmail)
        {
            InitializeComponent();
            BindingContext = new ResultViewModel(qrCodeText,isContact,isEvent,isPhoneNr,isEmail);
        }
    }
}