using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using QR_CodeScanner.Views;
using QR_CodeScanner.ViewModel;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Globalization;
using QR_CodeScanner.Model;

namespace QR_CodeScanner.ViewModel
{
    public class TextViewModel : BaseViewModel
    {
        string entry, editorCulture, buttonCulture, titleCulture;
        CultureLang culture;
        public ICommand ButtonGeneratorPageClicked { get; set; }
        public INavigation Navigation { get; set; }
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
        public string EntryText
        {
            get => entry;
            set => SetProperty(ref entry, value);
        }
        public string EditorCulture
        {
            get => editorCulture;
            set => SetProperty(ref editorCulture, value);
        }
        public string ButtonCulture
        {
            get => buttonCulture;
            set => SetProperty(ref buttonCulture, value);
        }
        public string TitleCulture
        {
            get => titleCulture;
            set => SetProperty(ref titleCulture, value);
        }
        [Obsolete]
        public TextViewModel(INavigation navigation, Color background, Color button, Color txt, Color frame, Color border)
        {
            this.Navigation = navigation;
            culture = new CultureLang();
            Background = background;
            Button = button;
            Txt = txt;
            Frame = frame;
            Border = border;
            if (culture.GetCulture() == "de")
            {
                EditorCulture = "Text eintragen";
                ButtonCulture = "QR-Code generieren";
                TitleCulture = "Text QR-Code generieren";
            }
            else
            {
                EditorCulture = "Add Text";
                ButtonCulture = "Generate QR-Code";
                TitleCulture = "Generate Text QR-Code";
            }
            ButtonGeneratorPageClicked = new Command(async () => await CallQRGeneratorPage());
        }

        [Obsolete]
        public async Task CallQRGeneratorPage()
        {
            await Navigation.PushAsync(new QRGeneratorPage(EntryText, false, false, false, false, false, false, false, false, false, string.Empty, false, Background, Frame));
        }

    }
}
