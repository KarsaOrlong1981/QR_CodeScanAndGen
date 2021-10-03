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
    public partial class QRVersionPage : ContentPage
    {
        [Obsolete]
        public QRVersionPage()
        {
            InitializeComponent();
            BindingContext = new QRVersionViewModel(Navigation);
           
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }
    }
}