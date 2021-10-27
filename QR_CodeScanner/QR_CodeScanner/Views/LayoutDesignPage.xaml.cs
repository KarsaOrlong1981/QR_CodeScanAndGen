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
    public partial class LayoutDesignPage : ContentPage
    {
        [Obsolete]
        public LayoutDesignPage(Color background, string logo)
        {
            InitializeComponent();
            BindingContext = new LayoutDesignViewModel(Navigation, mainGrid, this, background, logo);
        }
    }
}