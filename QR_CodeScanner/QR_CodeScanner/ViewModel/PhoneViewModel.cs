using System;
using System.Collections.Generic;
using System.Text;
using QR_CodeScanner.Views;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace QR_CodeScanner.ViewModel
{

    public class PhoneViewModel : BaseViewModel
    {
        string phoneNumber;
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
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }
        [Obsolete]
        public PhoneViewModel(INavigation navigation,Color background, Color button, Color txt, Color frame, Color border)
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

            await Navigation.PushAsync(new QRGeneratorPage(PhoneNumber, false, false, false, false, true, false, false, false, false, string.Empty, false, Background, Frame));
        }
       

    }
}
