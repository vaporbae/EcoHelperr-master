using EcoHelper.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace EcoHelper.Data
{
    public class InterestingFactDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public InterestingFactDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<InterestingFact>();
        }

        public InterestingFact GetInterestingFact(int id)
        {
            lock (locker)
            {
                if (database.Table<InterestingFact>().Count() == 0) return null;
                else return database.Table<InterestingFact>().FirstOrDefault(x => x.Id == id);
            }
        }

        public InterestingFact GetRandomInterestingFact()
        {
            lock (locker)
            {
                if (database.Table<InterestingFact>().Count() == 0) return null;
                else return database.Table<InterestingFact>().OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            }
        }

        public List<InterestingFact> GetInterestingFacts()
        {
            lock (locker)
            {
                if (database.Table<InterestingFact>().Count() == 0) return null;
                else return database.Table<InterestingFact>().ToList();
            }
        }

        public InterestingFact CreateInterestingFact(string title, string description, int? dumpsterId)
        {
            lock (locker)
            {
                database.Insert(new InterestingFact(title, description, dumpsterId));
            }
            return database.Table<InterestingFact>().Last();
        }
    }
}
