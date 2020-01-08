using EcoHelper.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace EcoHelper.Data
{
    class BaseVersionDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public BaseVersionDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<DatabaseVersion>();
        }

        public void ResetTable()
        {
            database.DropTable<DatabaseVersion>();
            database.CreateTable<DatabaseVersion>();
        }

        public void DeleteDatabaseVersionTable()
        {
            database.DropTable<DatabaseVersion>();
            database.CreateTable<DatabaseVersion>();
        }

        public DatabaseVersion GetLastDatabaseVersion()
        {
            lock (locker)
            {
                if (database.Table<DatabaseVersion>().Count() == 0) return null;
                else return database.Table<DatabaseVersion>().OrderByDescending(x=>x.Ver).FirstOrDefault();
            }
        }

        public List<DatabaseVersion> GetDatabaseVersions()
        {
            lock (locker)
            {
                if (database.Table<DatabaseVersion>().Count() == 0) return null;
                else return database.Table<DatabaseVersion>().ToList();
            }
        }

        public DatabaseVersion CreateDatabaseVersion(double version)
        {
            lock (locker)
            {
                database.Insert(new DatabaseVersion(version));
            }
            return database.Table<DatabaseVersion>().Last();
        }

    }
}
