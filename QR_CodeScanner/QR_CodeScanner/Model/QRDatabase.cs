

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
        public QRDatabase(string dbPath, string operation)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            if (operation == "gen")
                _database.CreateTableAsync<QRhistory>().Wait();
            if (operation == "scan")
                _database.CreateTableAsync<ScanHistoryModel>().Wait();
            if (operation == "lay")
                _database.CreateTableAsync<SaveLayoutModel>().Wait();
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
            if (item != null)
            {
                await _database.DeleteAsync(item);
            }
        }

        public Task<int> DeleteAllItems<T>()
        {
            return _database.DeleteAllAsync<QRhistory>();
        }
        //For Scan History
        public Task<int> SaveScanQRcodeAsync(ScanHistoryModel scanHistoryModel)
        {
            return _database.InsertAsync(scanHistoryModel);
        }

        public Task<List<ScanHistoryModel>> GetScanQRcodeAsync()
        {
            return _database.Table<ScanHistoryModel>().ToListAsync();
        }
        public async Task DeleteScanItemAsync(int id)
        {
            var item = await _database.Table<ScanHistoryModel>().Where(x => x.ScanID == id).FirstOrDefaultAsync();
            if (item != null)
            {
                await _database.DeleteAsync(item);
            }
        }

        public Task<int> DeleteAllScanItems<T>()
        {
            return _database.DeleteAllAsync<ScanHistoryModel>();
        }
        //For Layout
        public Task<List<SaveLayoutModel>> GetLayoutAsync()
        {
            return _database.Table<SaveLayoutModel>().ToListAsync();
        }
        public Task<int> SaveLayoutAsync(SaveLayoutModel saveLayoutModel)
        {
            return _database.InsertAsync(saveLayoutModel);
        }
        public Task<int> DeleteAllLayoutItems<T>()
        {
            return _database.DeleteAllAsync<SaveLayoutModel>();
        }
        public Task<int> GetLayoutCount()
        {
            return _database.Table<SaveLayoutModel>().CountAsync();
        }

    }


}
