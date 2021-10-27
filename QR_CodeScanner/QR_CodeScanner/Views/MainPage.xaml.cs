using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QR_CodeScanner.Model;
using QR_CodeScanner.ViewModel;
using QR_CodeScanner.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        Color background;
        string mainIMG;
        [Obsolete]
        public MainPage(Color background, Color txtC, Color button, Color border, Color btnTxt, string generateIMG, string historyScanIMG, string historyGenIMG, string mainIMG)
        {
            InitializeComponent();
            this.background = background;
            this.mainIMG = mainIMG;
            BindingContext = new MainViewModel(Navigation, background, txtC, button, border, btnTxt, generateIMG, historyScanIMG, historyGenIMG, mainIMG);
        }
        [Obsolete]
        private void design_Clicked(object sender, EventArgs e)
        {
            CallLayoutPage(background);
        }

        [Obsolete]
        private async void CallLayoutPage(Color background)
        {
            LayoutDesignPage call = new LayoutDesignPage(background, mainIMG);
            await Navigation.PushAsync(call);
            Navigation.RemovePage(this);
        }
    }
}