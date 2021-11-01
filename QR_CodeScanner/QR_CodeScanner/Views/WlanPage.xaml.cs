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
    public partial class WlanPage : ContentPage
    {
        [Obsolete]
        public WlanPage(Color background, Color button, Color txt, Color frame, Color border)
        {
            InitializeComponent();
            this.BackgroundColor = background;
            this.frameRow0.BackgroundColor = button;
            this.frameRow0.BorderColor = frame;
            this.entryRow0.TextColor = txt;
            this.entryRow0.PlaceholderColor = txt;
            this.frameRow1.BackgroundColor = button;
            this.frameRow1.BorderColor = frame;
            this.entryRow1.TextColor = txt;
            this.entryRow1.PlaceholderColor = txt;
            this.btn_Row1_btn1.BackgroundColor = button;
            this.btn_Row1_btn1.TextColor = txt;
            this.btn_Row1_btn1.BorderColor = frame;
            this.btn_Row1_btn2.BackgroundColor = button;
            this.btn_Row1_btn2.TextColor = txt;
            this.btn_Row1_btn2.BorderColor = frame;
            this.btn_Row1_btn3.BackgroundColor = button;
            this.btn_Row1_btn3.TextColor = txt;
            this.btn_Row1_btn3.BorderColor = frame;
            this.frameRow2.BackgroundColor = button;
            this.frameRow2.BorderColor = frame;
            this.entryRow2.TextColor = txt;
            this.entryRow2.PlaceholderColor = txt;
            this.btn_Generate.BackgroundColor = frame;
            this.btn_Generate.TextColor = background;
            this.btn_Generate.BorderColor = button;
            BindingContext = new WLanViewModel(Navigation);
        }

    }
}