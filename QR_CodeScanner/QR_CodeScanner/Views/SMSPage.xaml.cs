using QR_CodeScanner.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SMSPage : ContentPage
    {
        [Obsolete]
        public SMSPage()
        {
            InitializeComponent();
            BindingContext = new SMSViewModel(Navigation);
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }
    }
}