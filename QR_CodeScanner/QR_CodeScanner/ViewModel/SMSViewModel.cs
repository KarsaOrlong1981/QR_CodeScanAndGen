using QR_CodeScanner.Model;
using QR_CodeScanner.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QR_CodeScanner.ViewModel
{
    public class SMSViewModel : BaseViewModel
    {
        string sms,number;
        string editorCulture,buttonCulture,titleCulture,numberCulture;
        public INavigation Navigation { get; set; }
        public ICommand ButtonGeneratorPageClicked { get; set; }

        CultureLang culture;
        [Obsolete]
        public SMSViewModel(INavigation navigation)
        {

            this.Navigation = navigation;
            ButtonGeneratorPageClicked = new Command(async () => await CallQRGeneratorPage());
            culture = new CultureLang();

            if (culture.GetCulture() == "de")
            {
                NumberCulture = "Telefonnummer";
                EditorCulture = "Nachricht eintragen";
                ButtonCulture = "QR-Code generieren";
                TitleCulture = "SMS QR-Code generieren";
            }
            else
            {
                NumberCulture = "Phonenumber";
                EditorCulture = "Add Message";
                ButtonCulture = "Generate QR-Code";
                TitleCulture = "Generate SMS QR-Code";
            }
        }

        [Obsolete]
        public async Task CallQRGeneratorPage()
        {
            
            await Navigation.PushAsync(new QRGeneratorPage(Message, false, false, false, false,true,false,false,Number));
        }

        public string Message
        {
            get => sms;
            set => SetProperty(ref sms, value);
        }
        public string Number
        {
            get => number;
            set => SetProperty(ref number, value);
        }
        public string EditorCulture
        {
            get => editorCulture;
            set => SetProperty(ref editorCulture, value);
        }
        public string NumberCulture
        {
            get => numberCulture;
            set => SetProperty(ref numberCulture, value);
        }
        public string ButtonCulture
        {
            get => buttonCulture;
            set => SetProperty(ref buttonCulture, value);
        }
        public string TitleCulture
        {
            get => titleCulture ;
            set => SetProperty(ref titleCulture, value);
        }
    }
}
