using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using QR_CodeScanner.Views;
using Xamarin.Forms;
using QR_CodeScanner.Model;

namespace QR_CodeScanner.ViewModel
{
    public class WebsiteViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        #region ICommands
        public ICommand ButtonHTTPSClicked { get; set; }
        public ICommand ButtonHTTPClicked { get; set; }
        public ICommand ButtonWWWClicked { get; set; }
        public ICommand ButtonCOMClicked { get; set; }
        public ICommand ButtonDEClicked { get; set; }
        public ICommand ButtonGeneratorPageClicked { get; set; }
        #endregion // ICommands

        #region DesignColor Propertys
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
        #endregion // DesignColor Propertys
        #region Propertys
        string entry, entryCulture, buttonCulture, titleCulture;
        public string EntryText
        {
            get => entry;
            set => SetProperty(ref entry, value);
        }
        public string EntryTextCulture
        {
            get => entryCulture;
            set => SetProperty(ref entryCulture, value);
        }
        public string TitleCulture
        {
            get => titleCulture;
            set => SetProperty(ref titleCulture, value);
        }
        public string ButtonCulture
        {
            get => buttonCulture;
            set => SetProperty(ref buttonCulture, value);
        }
        #endregion //Propertys
        #region Command Events
        void HTTPS_Clicked()
        {
            EntryText = "";
            EntryText = "https://";
        }
        void HTTP_Clicked()
        {
            EntryText = "";
            EntryText = "http://";
        }
        void WWW_Clicked()
        {
            EntryText += "www.";
        }
        void COM_Clicked()
        {
            EntryText += ".com";
        }
        void DE_Clicked()
        {
            EntryText += ".de";
        }
        #endregion // Command Events
        [Obsolete]
        public WebsiteViewModel(INavigation navigation, Color background, Color button, Color txt, Color frame, Color border)
        {

            this.Navigation = navigation;
            Background = background;
            Button = button;
            Txt = txt;
            Frame = frame;
            Border = border;
            ButtonGeneratorPageClicked = new Command(async () => await CallQRGeneratorPage());
            ButtonHTTPSClicked = new Command(HTTPS_Clicked);
            ButtonHTTPClicked = new Command(HTTP_Clicked);
            ButtonWWWClicked = new Command(WWW_Clicked);
            ButtonCOMClicked = new Command(COM_Clicked);
            ButtonDEClicked = new Command(DE_Clicked);

            if (CultureLanguage.GetCulture() == "de")
            {
                EntryTextCulture = "Website";
                ButtonCulture = "QR-Code generieren";
                TitleCulture = "Website QR-Code generieren";
            }
            else
            {
                EntryTextCulture = "Website";
                ButtonCulture = "Generate QR-Code";
                TitleCulture = "Generate Website QR-Code";
            }
        }

        [Obsolete]
        public async Task CallQRGeneratorPage()
        {
            await Navigation.PushAsync(new QRGeneratorPage(EntryText, false, true, false, false, false, false, false, false, false, string.Empty, false, Background, Frame));
        }
    }
}
