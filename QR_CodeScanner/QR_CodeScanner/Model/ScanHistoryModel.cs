using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR_CodeScanner.Model
{
    public class ScanHistoryModel
    {
        [PrimaryKey, AutoIncrement]
        public int ScanID { get; set; }
        public string ScanQRText { get; set; }
        public string ScanEvent { get; set; }
        public DateTime ScanDate { get; set; }
    }
}
