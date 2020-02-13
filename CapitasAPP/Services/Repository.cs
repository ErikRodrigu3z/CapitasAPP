using CapitasAPP.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CapitasAPP.Services
{
    public class Repository<T> where T : class, new()
    {
       
        private readonly SQLiteAsyncConnection _db;
        private readonly SQLiteConnection _dbNoAsync; 

        public Repository(bool BorrarDB = false)
        {
            _db = new SqliteContext().GetConnectionAsync();

            if (BorrarDB)
            {
                File.Delete(Constants.DatabasePath);
                _db.CreateTableAsync<Persona>().Wait();
                _db.CreateTableAsync<Capitas>().Wait();
                _db.CreateTableAsync<Configuracion>().Wait();
            }

        }

        public async Task<bool> AddItem(T item)
        {
            try
            {
                int res = await _db.InsertAsync(item);
                if (res > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<bool> DeleteItem(T item)
        {

            return isSucces(await _db.DeleteAsync(item));
        }

        public async Task<List<T>> FindItems(Expression<Func<T, bool>> predicate)
        {

            return await _db.Table<T>().Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync() 
        { 

            return await _db.Table<T>().ToListAsync();
        }

        public List<T> GetAll()
        {

            return _dbNoAsync.Table<T>().ToList();
        }

        public async Task<T> GetItem(int pk)
        {

            return await _db.GetAsync<T>(pk);
        }

        public async Task<T> GetItem(Expression<Func<T, bool>> predicate)
        {

            return await _db.GetAsync<T>(predicate);
        }

        public async Task<bool> InsertItem(T item)
        {

            return isSucces(await _db.InsertAsync(item));
        }

        public async Task<bool> InsertItems(IEnumerable<T> items)
        {

            foreach (T item in items)
            {
                await _db.InsertAsync(item);
            }
            return true;
        }

        public async Task<bool> UpdateItem(T item)
        {
            try
            {
                return isSucces(await _db.InsertOrReplaceAsync(item));
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }

        private bool isSucces(int rowsAffected)
        {
            if (rowsAffected > 0)
                return true;
            return false;
        }

    }
}
