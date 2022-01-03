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
    public partial class EventPage : ContentPage
    {
        [Obsolete]
        public EventPage(Color background, Color button, Color txt, Color frame, Color border)
        {
            InitializeComponent();

            BindingContext = new EventViewModel(Navigation, background, button, txt, frame, border);
            btn_generate.IsEnabled = false;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (entry.Text == "")
                btn_generate.IsEnabled = false;
            else
                btn_generate.IsEnabled = true;
        }

    }
}