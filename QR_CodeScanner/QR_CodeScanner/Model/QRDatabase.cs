using QR_CodeScanner.Model;

using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace QR_CodeScanner.Model
{
	
	public class QRDatabase 
	{
        readonly SQLiteAsyncConnection _database;

        public QRDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<QRprogress>().Wait();
        }

        public Task<List<QRprogress>> GetQRcodeAsync()
        {
            return _database.Table<QRprogress>().ToListAsync();
        }

        public Task<int> SaveQRcodeAsync(QRprogress qrCode)
        {
            return _database.InsertAsync(qrCode);
        }
    }


}
