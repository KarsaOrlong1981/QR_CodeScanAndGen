using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace QR_CodeScanner.Model
{
    public class ShareContent
    {
        public async Task ShareText(string text)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = "Share Text"
            });
        }

        public async Task ShareUri(string uri)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = uri,
                Title = "Share Web Link"
            });
        }

        public async Task ShareFile(string title, string filepath)
        {

            await Share.RequestAsync(new ShareFileRequest()
            {
                Title = title,
                File = new ShareFile(filepath)
            });
        }

        [Obsolete]
        public async Task<string> CaptureScreenshot()
        {
            var screenshot = await Screenshot.CaptureAsync();
            var stream = await screenshot.OpenReadAsync();

            var file = System.IO.Path.Combine(FileSystem.CacheDirectory, "screenshot.png");
            using (FileStream fs = File.Open(file, FileMode.Create))
            {
                await stream.CopyToAsync(fs);
                await fs.FlushAsync();
            }
            return file;
        }

    }
}
