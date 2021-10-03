using Android.App;
using Android.Content;
using Android.Net.Wifi;
using Android.Widget;
using QR_CodeScanner.Model;
using QR_CodeScanner.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(WifiConnector))]

namespace QR_CodeScanner.Model 
{
    public class WifiConnector : IWifiConnector
    {
        CultureLang culture;
        public WifiConnector()
        {
            culture = new CultureLang();
        }

        [Obsolete]
        public void ConnectToWifi(string ssid, string password)
        {
            var wifi = DependencyService.Get<IWifiConnector>();
            var wifiManager = (WifiManager)Android.App.Application.Context.GetSystemService(Context.WifiService);
            var formattedSsid = $"\"{ssid}\"";
            var formattedPassword = $"\"{password}\"";

            var wifiConfig = new WifiConfiguration
            {
                Ssid = formattedSsid,
                PreSharedKey = formattedPassword
            };
            var addNetwork = wifiManager.AddNetwork(wifiConfig);
            var network = wifiManager.ConfiguredNetworks.FirstOrDefault(n => n.Ssid == ssid);

            if (network == null)
            {

                NoConnection(ssid);
                
                return;
            }
            wifiManager.Disconnect();
            var enableNetwork = wifiManager.EnableNetwork(network.NetworkId, true);
            var activity = Forms.Context as Activity;
            if (culture.GetCulture() == "de")

                Toast.MakeText(activity, "Wlan Netzwerk wurde geändert", ToastLength.Long).Show();

            else

                Toast.MakeText(activity, "Wlan has changed.", ToastLength.Long).Show();
        }

        [Obsolete]
        private void NoConnection(string ssid)
        {
            var activity = Forms.Context as Activity;
            if (culture.GetCulture() == "de")

                Toast.MakeText(activity, ssid + " kann nicht mit dem Netzwerk verbunden werden.", ToastLength.Long).Show();

            else

                Toast.MakeText(activity, "Cannot connect to network: " + ssid, ToastLength.Long).Show();
        }
    }
}
