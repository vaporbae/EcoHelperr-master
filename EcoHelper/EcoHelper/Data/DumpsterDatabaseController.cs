using EcoHelper.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace EcoHelper.Data
{
    public class DumpsterDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public DumpsterDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Dumpster>();
        }

        public void ResetTable()
        {
            database.DropTable<Dumpster>();
            database.CreateTable<Dumpster>();
        }

        public void AddGarbage(Garbage garbage, int id)
        {
            lock (locker)
            {
                var dumpster = database.GetWithChildren<Dumpster>(id);
                dumpster.Garbages.Add(garbage);
                database.UpdateWithChildren(dumpster);
            }
        }

        public void AddInterestingFact(InterestingFact interestingFact, int id)
        {
            lock (locker)
            {
                var dumpster = database.GetWithChildren<Dumpster>(id);
                dumpster.InterestingFacts.Add(interestingFact);
                database.UpdateWithChildren(dumpster);
            }
        }

        public Dumpster GetDumpster(int id)
        {
            lock (locker)
            {
                if (database.Table<Dumpster>().Count() == 0) return null;
                else return database.GetWithChildren<Dumpster>(id);
            }
        }

        public List<Dumpster> GetDumpsters()
        {
            lock (locker)
            {
                if (database.Table<Dumpster>().Count() == 0) return null;
                else return database.GetAllWithChildren<Dumpster>();
            }
        }

        public Dumpster CreateDumpster(string name)
        {
            lock (locker)
            {
                database.Insert(new Dumpster(name));
            }
            return database.Table<Dumpster>().Last();
        }
    }
}
