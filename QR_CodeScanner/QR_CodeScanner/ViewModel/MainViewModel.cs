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
    public class MainViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public ICommand ButtonGeneratorClicked { get; set; }
        public ICommand ButtonInfoClicked { get; set; }
        public ICommand ButtonProgressClicked { get; set; }
        public ICommand ButtonScannerClicked { get; set; }
        public ICommand ButtonScanHistoryClicked { get; set; }
        QRhistory progress;
        CultureLang culture;
        string historyGen, historyScan, scanWithCam;
        Color background, txtC, button, border, btnTxtC;
        string generateIMG, historyScanIMG, historyGenIMG, mainIMG;
        public Color Background
        {
            get => background;
            set => SetProperty(ref background, value);
        }
        public Color TXTC
        {
            get => txtC;
            set => SetProperty(ref txtC, value);
        }
        public Color Button
        {
            get => button;
            set => SetProperty(ref button, value);
        }
        public Color Border
        {
            get => border;
            set => SetProperty(ref border, value);
        }
        public Color BtnTxt
        {
            get => btnTxtC;
            set => SetProperty(ref btnTxtC, value);
        }
        public string GenerateIMG
        {
            get => generateIMG;
            set => SetProperty(ref generateIMG, value);
        }
        public string HistoryGenIMG
        {
            get => historyGenIMG;
            set => SetProperty(ref historyGenIMG, value);
        }
        public string HistoryScanIMG
        {
            get => historyScanIMG;
            set => SetProperty(ref historyScanIMG, value);
        }
        public string MainIMG
        {
            get => mainIMG;
            set => SetProperty(ref mainIMG, value);
        }
        public string HistoryGen
        {
            get => historyGen;
            set => SetProperty(ref historyGen, value);
        }
        public string HistoryScan
        {
            get => historyScan;
            set => SetProperty(ref historyScan, value);
        }
        public string ScanWithCam
        {
            get => scanWithCam;
            set => SetProperty(ref scanWithCam, value);
        }

        [Obsolete]
        public MainViewModel(INavigation navigation, Color background, Color txtC, Color button, Color border, Color btnTxt, string generateIMG, string historyScanIMG, string historyGenIMG, string mainIMG)
        {
            this.Navigation = navigation;
            Background = background;
            TXTC = txtC;
            Button = button;
            Border = border;
            BtnTxt = btnTxt;
            GenerateIMG = generateIMG;
            HistoryScanIMG = historyScanIMG;
            HistoryGenIMG = historyGenIMG;
            MainIMG = mainIMG;
            culture = new CultureLang();
            progress = new QRhistory();
            ButtonGeneratorClicked = new Command(async () => await CallQRVersionPage());
            ButtonScannerClicked = new Command(async () => await CallScannerPage());
            ButtonProgressClicked = new Command(async () => await CallHistoryPage());
            ButtonScanHistoryClicked = new Command(async () => await CallScanHistoryPage());
            ButtonInfoClicked = new Command(async () => await CallInfoPage());
            if (culture.GetCulture() == "de")
            {
                ScanWithCam = "Mit Kamera Scannen";
                HistoryGen = "Generierte\nQR-Codes\nVerlauf";
                HistoryScan = "Gescannte\nQR-Codes\nVerlauf";
            }
            else
            {
                ScanWithCam = "Scan with Camera";
                HistoryGen = "Generated\nHistory";
                HistoryScan = "Scanned\nHistory";
            }
        }
        [Obsolete]
        private async Task CallHistoryPage()
        {
            await Navigation.PushAsync(new HistoryPage(null, null, false));
        }
        //hier muss ich alle farben übergeben
        [Obsolete]
        private async Task CallQRVersionPage()
        {
            await Navigation.PushAsync(new QRVersionPage(Background, Button, TXTC, Border, BtnTxt));
        }
        private async Task CallScannerPage()
        {
            await Navigation.PushAsync(new ScannerPage(background, button));
        }

        private async Task CallScanHistoryPage()
        {
            await Navigation.PushAsync(new ScanHistory(null, null, false, background, button));
        }

        private async Task CallInfoPage()
        {
            await Navigation.PushAsync(new InfoPage());
        }


    }
}
