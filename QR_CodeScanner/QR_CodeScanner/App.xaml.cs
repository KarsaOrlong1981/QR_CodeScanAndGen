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
        public static QRDatabase Database1
        {
            get
            {
                if (database1 == null)
                {
                    database1 = new QRDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QRcodeHistory.db1"), true);
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
                    database2 = new QRDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ScanHistory.db1"), false);
                }
                return database2;
            }
        }

        [Obsolete]
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPageViewModel()) { BarBackgroundColor = Color.SteelBlue, BarTextColor = Color.White };
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
