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
    public partial class QRVersionPage : ContentPage
    {
        public QRVersionPage()
        {
            InitializeComponent();
        }
        async void CallWebsitePage()
        {
            WebsitePage call = new WebsitePage();
            await Navigation.PushAsync(call);
        }

        private void btn_Website_Clicked(object sender, EventArgs e)
        {
            CallWebsitePage();
        }
    }
}