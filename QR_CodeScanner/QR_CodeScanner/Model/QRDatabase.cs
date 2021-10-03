

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
            _database.CreateTableAsync<QRhistory>().Wait();
        }

        public Task<List<QRhistory>> GetQRcodeAsync()
        {
            return _database.Table<QRhistory>().ToListAsync();
        }

        public Task<int> SaveQRcodeAsync(QRhistory qrCode)
        {
            return _database.InsertAsync(qrCode);
        }
       public async Task DeleteItemAsync(int id)
        {
            var item = await _database.Table<QRhistory>().Where(x => x.ID == id).FirstOrDefaultAsync();
            if(item != null)
            {
                await _database.DeleteAsync(item);
            }
        }
        public Task<int> DeleteAllItems<T>()
        {
            return _database.DeleteAllAsync<QRhistory>();
        }

    }


}
