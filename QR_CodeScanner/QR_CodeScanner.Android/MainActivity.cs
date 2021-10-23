using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using Android;
using Android.Content;
using Android.Provider;
using System.Collections.Generic;
using Android.Util;
using Google.Android.Material.Snackbar;

using QR_CodeScanner.Views;
using Android.Support.V4.App;
using Android.Widget;

using Java.Interop;
using QR_CodeScanner.Droid.Models;
using System.IO;
using AndroidX.AppCompat.App;

namespace QR_CodeScanner.Droid
{
   

    [Activity(Label = "QR_CodeScanner", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        [Obsolete]
#pragma warning disable CS0809 // Veraltetes Element überschreibt nicht veraltetes Element
        protected override void OnCreate(Bundle savedInstanceState)
#pragma warning restore CS0809 // Veraltetes Element überschreibt nicht veraltetes Element
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightNo;

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