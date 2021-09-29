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
    public partial class ProgressPage : ContentPage
    {
        public ProgressPage(string qrText)
        {
            InitializeComponent();
            if(qrText != null)
            AddToDB(qrText);

        }
       
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetQRcodeAsync();
        }

        private async void AddToDB(string qrTxt)
        {
            if (!string.IsNullOrWhiteSpace(qrTxt))
            {
                
                await App.Database.SaveQRcodeAsync(new Model.QRprogress
                {
                    QRText = qrTxt ,
                    
                    Date = DateTime.Now ,
                });


               
                collectionView.ItemsSource = await App.Database.GetQRcodeAsync();
            }
        }
    }
}