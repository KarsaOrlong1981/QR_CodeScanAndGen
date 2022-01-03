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
    public partial class PhonePage : ContentPage
    {
        [Obsolete]
        public PhonePage(Color background, Color button, Color txt, Color frame, Color border)
        {
            InitializeComponent();
            BindingContext = new PhoneViewModel(Navigation, background, button, txt, frame, border);
            btn_Generate.IsEnabled = false;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (entry.Text == "")
                btn_Generate.IsEnabled = false;
            else
                btn_Generate.IsEnabled = true;
        }
    }
}