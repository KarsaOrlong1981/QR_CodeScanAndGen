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
        static QRDatabase database;

        public static QRDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new QRDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "qrcodeScannAndGen.db2"));
                }
                return database;
            }
        }
        [Obsolete]
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.SteelBlue, BarTextColor = Color.White };
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
