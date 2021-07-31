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
    public partial class WebsitePage : ContentPage
    {
        public WebsitePage()
        {
            InitializeComponent();
        }
        async void CallQR_Generator()
        {
            QRGeneratorPage call = new QRGeneratorPage(entryWebsite.Text);
            await Navigation.PushAsync(call);
        }

        private void btn_HTTPS_Clicked(object sender, EventArgs e)
        {
            entryWebsite.Text = "";
            entryWebsite.Text = "https://";
        }

        private void btn_HTTP_Clicked(object sender, EventArgs e)
        {
            entryWebsite.Text = "";
            entryWebsite.Text = "http://";
        }

        private void btn_WWW_Clicked(object sender, EventArgs e)
        {
            
            entryWebsite.Text += "www.";
        }

        private void btn_Com_Clicked(object sender, EventArgs e)
        {
            
            entryWebsite.Text += ".com";
        }

        private void btn_DE_Clicked(object sender, EventArgs e)
        {
            entryWebsite.Text += ".de";
        }

        private void btn_Generate_Clicked(object sender, EventArgs e)
        {
            CallQR_Generator();
        }
    }
}