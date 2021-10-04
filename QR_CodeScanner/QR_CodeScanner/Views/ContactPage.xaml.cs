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
    public partial class ContactPage : ContentPage
    {
        [Obsolete]
        public ContactPage()
        {
            InitializeComponent();
            BindingContext = new ContactViewModel(Navigation);
            btn_Generate.IsEnabled = false;
        }



        private void entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (entry.Text == "")
                btn_Generate.IsEnabled = false;
            else
                btn_Generate.IsEnabled = true;
        }

    }
}