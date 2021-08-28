using System;
using System.Collections.Generic;
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

        public async Task ShareFile(string filename, string filepath)
        {

            await Share.RequestAsync(new ShareFileRequest()
            {
                Title = filename,
                File = new ShareFile(filepath)
            });


        }

    }
}
