using System;
using System.Collections.Generic;
using System.Text;

namespace QR_CodeScanner.Service
{
    public interface IWifiConnector
    {
        void ConnectToWifi(string ssid, string password);
    }
}
