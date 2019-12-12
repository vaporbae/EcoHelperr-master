using EcoHelper.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace EcoHelper.Data
{
    class GarbageDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public GarbageDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Garbage>();
        }

        public void DeleteGarbageTable()
        {
            database.DropTable<Garbage>();
            database.CreateTable<Garbage>();
        }

        public Garbage GetGarbage(int id)
        {
            lock (locker)
            {
                if (database.Table<Garbage>().Count() == 0) return null;
                else return database.Table<Garbage>().FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Garbage> GetGarbages()
        {
            lock (locker)
            {
                if (database.Table<Garbage>().Count() == 0) return null;
                else return database.Table<Garbage>().ToList();
            }
        }

        public void UpdateGarbage(int id, string name, int dumpsterId)
        {
            lock (locker)
            {
                var garbage = database.Table<Garbage>().First(x => x.Id == id);
                if (garbage == null) return;

                garbage.Name = name;
                garbage.DumpsterId = dumpsterId;
            }
        }

        public Garbage CreateGarbage(string name, int dumpsterId)
        {
            lock (locker)
            {
                database.Insert(new Garbage(name, dumpsterId));
            }
            return database.Table<Garbage>().Last();
        }

    }
}
