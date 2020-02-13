using CapitasAPP.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CapitasAPP.Services
{
    public class SqliteContext : IDisposable    
    {
       
        public SqliteContext() 
        {
            var _db = GetConnectionAsync();

            //if (!File.Exists(Constants.DatabasePath))
            //{
            //    _db.CreateTableAsync<Persona>().Wait();
            //    _db.CreateTableAsync<Capitas>().Wait();
            //    _db.CreateTableAsync<Configuracion>().Wait();
            //}

            //if (_db == null)
            //{
            //    _db.CreateTableAsync<Persona>().Wait();
            //    _db.CreateTableAsync<Capitas>().Wait();
            //    _db.CreateTableAsync<Configuracion>().Wait();
            //}
            _db.CreateTableAsync<Persona>().Wait();
            _db.CreateTableAsync<Capitas>().Wait();
            _db.CreateTableAsync<Configuracion>().Wait();
        }

        public void Dispose()
        {
            var con = GetConnection();
            con.Close();
            var conAsync = GetConnectionAsync();
            conAsync.CloseAsync();
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
        }

        public SQLiteAsyncConnection GetConnectionAsync()
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }
    }
}
