using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QR_CodeScanner.Views;
using Xamarin.Forms;

namespace QR_CodeScanner.ViewModel
{
    public class EmailViewModel : BaseViewModel
    {
        string email;
        public INavigation Navigation { get; set; }
        public ICommand ButtonGeneratorPageClicked { get; set; }
        Color background, button, txt, frame, border;
        public Color Background
        {
            get => background;
            set => SetProperty(ref background, value);
        }
        public Color Button
        {
            get => button;
            set => SetProperty(ref button, value);
        }
        public Color Txt
        {
            get => txt;
            set => SetProperty(ref txt, value);
        }
        public Color Frame
        {
            get => frame;
            set => SetProperty(ref frame, value);
        }
        public Color Border
        {
            get => border;
            set => SetProperty(ref border, value);
        }
        public string EmailADD
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        [Obsolete]
        public EmailViewModel(INavigation navigation, Color background, Color button, Color txt, Color frame, Color border)
        {
            this.Navigation = navigation;
            Background = background;
            Button = button;
            Txt = txt;
            Frame = frame;
            Border = border;
            ButtonGeneratorPageClicked = new Command(async () => await CallQRGeneratorPage());
        }
        [Obsolete]
        public async Task CallQRGeneratorPage()
        {

            await Navigation.PushAsync(new QRGeneratorPage(EmailADD, false, false, false, false, false, true, false, false, false, string.Empty, false, background, frame));
        }
      
    }
}
