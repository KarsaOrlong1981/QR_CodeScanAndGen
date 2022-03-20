using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QR_CodeScanner.Model
{
    public class QRImage
    {
        TaskCompletionSource<string> SaveQRComplete = null;
        ShareContent share;
        [Obsolete]
        public Task SaveQRAsImage(string text)
        {
            share = new ShareContent();
            SaveQRComplete = new TaskCompletionSource<string>();
            try
            {
                var barcodeWriter = new ZXing.BarcodeWriter<Bitmap> { Format = ZXing.BarcodeFormat.QR_CODE, Options = new ZXing.Common.EncodingOptions { Width = 1000, Height = 1000, Margin = 10 } };

                barcodeWriter.Renderer = new BitmapRenderer();
                var bitmap = barcodeWriter.Write(text);
                var stream = new MemoryStream();
                bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);  // this is the diff between iOS and Android
                stream.Position = 0;

                byte[] imageData = stream.ToArray();

                var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures);
                var pictures = dir.AbsolutePath;
                //adding a time stamp time file name to allow saving more than one image... otherwise it overwrites the previous saved image of the same name
                string name = "QR_Code_Scan_and_Gen" + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                string filePath = System.IO.Path.Combine(pictures, name);

                System.IO.File.WriteAllBytes(filePath, imageData);
                //mediascan adds the saved image into the gallery
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Android.Net.Uri.FromFile(new Java.IO.File(filePath)));

                Android.App.Application.Context.SendBroadcast(mediaScanIntent);
                SaveQRComplete.SetResult(filePath);
                return SaveQRComplete.Task;
            }
            catch
            {

                if (CultureLanguage.GetCulture() == "de")
                    WriteToast.ShowLongToast("Qr-Code konnte nicht gespeichert werden. Möglicherweise fehlt der Pictures Ordner auf dem Gerät.");
                else
                    WriteToast.ShowLongToast("Qr code could not be saved. The Pictures folder may be missing on the device.");
                return null;
            }

        }

        public void ShareQRAsImage(string text)
        {
            var barcodeWriter = new ZXing.BarcodeWriter<Bitmap> { Format = ZXing.BarcodeFormat.QR_CODE, Options = new ZXing.Common.EncodingOptions { Width = 1000, Height = 1000, Margin = 10 } };

            barcodeWriter.Renderer = new BitmapRenderer();
            var bitmap = barcodeWriter.Write(text);
            var stream = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
            stream.Position = 0;
            string filePath = System.IO.Path.Combine(FileSystem.CacheDirectory, "screenshot.png");
            byte[] imageData = stream.ToArray();
            System.IO.File.WriteAllBytes(filePath, imageData);
        }
    }
}
