using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace QR_CodeScanner.Model
{
    public class QRhistory
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string QRText { get; set; }
        public string Event { get; set; }
        public DateTime Date { get; set; }
    }
}
