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
    public partial class TextPage : ContentPage
    {
        [Obsolete]
        public TextPage()
        {
            InitializeComponent();
            BindingContext = new TextViewModel(Navigation);
            btn_Generate.IsEnabled = false;
        }

      

        private void editor_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (editor.Text == "")
                btn_Generate.IsEnabled = false;
            else
                btn_Generate.IsEnabled = true;
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }
    }
}