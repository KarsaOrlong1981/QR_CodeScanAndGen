using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QR_CodeScanner.ViewModel;
using QR_CodeScanner.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageViewModel : ContentPage
    {
        
       [Obsolete]
        public MainPageViewModel()
        {
            InitializeComponent();

            BindingContext = new MainViewModel(Navigation);
        }

     
    }
}