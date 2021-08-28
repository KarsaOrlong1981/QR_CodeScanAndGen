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
    public partial class WebsitePage : ContentPage
    {
        [Obsolete]
        public WebsitePage()
        {
            InitializeComponent();
            BindingContext = new WebsiteViewModel(Navigation);
        }
       

    
    }
}