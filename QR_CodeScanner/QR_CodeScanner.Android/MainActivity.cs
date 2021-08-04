using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;


namespace QR_CodeScanner.Droid
{
    // Schritte zum erstellen einer QR Scanner App
    //Nugent Pakete herunterladen ZXing.Net.Mobile.Forms für das projekt und ZXing.Net.Mobile extra für Android Projekt
    //Portrait modus aktivieren über ScreenOrientation 
    //Berechtigungen im AndroidManifest.xml hinzufügen <uses-permission android:name="android.permission.CAMERA" />
	//<uses-permission android:name="android.permission.FLASHLIGHT" />
    //Scanner Page erstellen und Code Behind anpassen

    [Activity(Label = "QR_CodeScanner", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //für BarCode Scanner
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            //für BarCode Scanner
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}