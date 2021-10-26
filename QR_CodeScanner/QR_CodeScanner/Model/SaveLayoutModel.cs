using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR_CodeScanner.Model
{
    public class SaveLayoutModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string LayoutDesign { get; set; }
    }
}
