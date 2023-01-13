using SQLite;
using APPHanzaBebe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPHanzaBebe.Services
{
    public class PacientService : IPacientService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Pacient.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<PacientModel>();
            }
        }

        public async Task<int> AddPacient(PacientModel pacientModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(pacientModel);
        }

        public async Task<int> DeletePacient(PacientModel pacientModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(pacientModel);
        }

        public async Task<List<PacientModel>> GetPacientList()
        {
            await SetUpDb();
            var pacientList = await _dbConnection.Table<PacientModel>().ToListAsync();
            return pacientList;
        }

        public async Task<int> UpdatePacient(PacientModel pacientModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(pacientModel);
        }
    }
}
