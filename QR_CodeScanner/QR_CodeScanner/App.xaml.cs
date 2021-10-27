using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QR_CodeScanner.Views;
using QR_CodeScanner.Model;
using System.IO;

namespace QR_CodeScanner
{
    public partial class App : Application
    {
        static QRDatabase database1;
        static QRDatabase database2;
        static QRDatabase dataBaseLayout;
        Color backgroundC, txtC, buttonC, borderC, buttonTxtC;
        Color overColor;
        string generateIMG, scanHIMG, genHIMG, mainIMG;
        string getLayout;

        public static QRDatabase Database1
        {
            get
            {
                if (database1 == null)
                {
                    database1 = new QRDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QRcodeHistory.db1"), "gen");
                }
                return database1;
            }
        }
        public static QRDatabase Database2
        {
            get
            {
                if (database2 == null)
                {
                    database2 = new QRDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ScanHistory.db1"), "scan");
                }
                return database2;
            }
        }
        public static QRDatabase DatabaseLayout
        {
            get
            {
                if (dataBaseLayout == null)
                {
                    dataBaseLayout = new QRDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DesignLayout.db3"), "lay");
                }
                return dataBaseLayout;
            }
        }
        public static NavigationPage NavPage { get; set; }
        [Obsolete]
        public App()
        {
            InitializeComponent();
            int result = 0;
            try
            {
                result = DatabaseLayout.GetLayoutCount().Result;
            }
            catch
            {

            }
            if (!(result == 0))
            {
                getLayout = DatabaseLayout.GetLayoutAsync().Result[0].LayoutDesign;
            }
            else
            {
                getLayout = "logoJediBlueIrishIR.png";
            }
            switch (getLayout)
            {
                case "logoJediBlueIrishIR.png":
                    backgroundC = Color.FromHex("678efo");
                    txtC = Color.FromHex("c99718");
                    buttonC = Color.FromHex("113182");
                    borderC = Color.FromHex("1c55e6");
                    buttonTxtC = Color.FromHex("ffffffff");
                    generateIMG = "Gen24C99.png";
                    scanHIMG = "ScanHC99.png";
                    genHIMG = "verlaufC99.png";
                    mainIMG = "logoJediBlueIrishIR.png";
                    break;
                case "logoAzureLime.png":
                    backgroundC = Color.FromHex("3a86ff");
                    txtC = Color.FromHex("fa2878");
                    buttonC = Color.FromHex("064ab8");
                    borderC = Color.FromHex("56de02");
                    buttonTxtC = Color.FromHex("56e600");
                    generateIMG = "generateLime24.png";
                    scanHIMG = "scanHistLime24.png";
                    genHIMG = "verlaufLime24.png";
                    mainIMG = "logoAzureLime.png";
                    break;
                case "logoCaliforniaHereICome.png":
                    backgroundC = Color.FromHex("53a7b8");
                    txtC = Color.FromHex("ffffffff");
                    buttonC = Color.FromHex("f27157");
                    borderC = Color.FromHex("1bd5fa");
                    buttonTxtC = Color.FromHex("ffffffff");
                    generateIMG = "generateCali24.png";
                    scanHIMG = "scanHistCali24.png";
                    genHIMG = "verlaufCali24.png";
                    mainIMG = "logoCaliforniaHereICome.png";
                    break;
                case "logoMangoJazzberry.png":
                    backgroundC = Color.FromHex("ffbd00");
                    txtC = Color.FromHex("ff5400");
                    buttonC = Color.FromHex("390099");
                    borderC = Color.FromHex("ff0054");
                    buttonTxtC = Color.FromHex("390099");
                    generateIMG = "generateJazzberry24.png";
                    scanHIMG = "scanHistJazzberry24.png";
                    genHIMG = "verlaufJazzberry24.png";
                    mainIMG = "logoMangoJazzberry.png";
                    break;
                case "logoModernPolit.png":
                    backgroundC = Color.FromHex("defc44");
                    txtC = Color.FromHex("defc44");
                    buttonC = Color.FromHex("9f09bd");
                    borderC = Color.FromHex("364ec7");
                    buttonTxtC = Color.FromHex("364ec7");
                    generateIMG = "generateModern24.png";
                    scanHIMG = "scanHistModern24.png";
                    genHIMG = "verlaufModern24.png";
                    mainIMG = "logoModernPolit.png";
                    break;
                case "logoSpringGreenWhite.png":
                    backgroundC = Color.FromHex("ffffffff");
                    txtC = Color.FromHex("ffffffff");
                    buttonC = Color.FromHex("556b2f");
                    borderC = Color.FromHex("00ff7f");
                    buttonTxtC = Color.Black;
                    generateIMG = "Gen24.png";
                    scanHIMG = "ScanH.png";
                    genHIMG = "verlauf.png";
                    mainIMG = "logoSpringGreenWhite.png";
                    break;
                case "logoDarkMode.png":
                    backgroundC = Color.FromHex("292929");
                    txtC = Color.FromHex("1bd5fa");
                    buttonC = Color.Black;
                    borderC = Color.FromHex("53a7b8");
                    buttonTxtC = Color.FromHex("1bd5fa");
                    generateIMG = "Gen24.png";
                    scanHIMG = "ScanH.png";
                    genHIMG = "verlauf.png";
                    mainIMG = "logoDarkMode.png";
                    break;
            }
            if (mainIMG == "logoJediBlueIrishIR.png" || mainIMG == "logoModernPolit.png")
                overColor = txtC;
            else
                overColor = borderC;
            if (mainIMG == "logoCaliforniaHereICome.png")
                overColor = Color.White;
            NavPage = new NavigationPage(new MainPage(backgroundC, txtC, buttonC, borderC, buttonTxtC, generateIMG, scanHIMG, genHIMG, mainIMG)) { BarBackgroundColor = buttonC, BarTextColor = overColor };
            MainPage = NavPage;
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
