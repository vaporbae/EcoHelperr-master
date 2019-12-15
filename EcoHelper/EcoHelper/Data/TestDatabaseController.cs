using EcoHelper.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace EcoHelper.Data
{
    class TestDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public TestDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Test>();
            database.CreateTable<TestQuestion>();
        }

        public void ResetTable()
        {
            database.DropTable<Test>();
            database.CreateTable<Test>();
        }

        public Test GetTest(int id)
        {
            lock (locker)
            {
                if (database.Table<Test>().Count() == 0) return null;
                else return database.Table<Test>().FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Test> GetTests()
        {
            lock (locker)
            {
                if (database.Table<Test>().Count() == 0) return null;
                else return database.Table<Test>().ToList();
            }
        }

        public List<Test> GetUserTests(int id)
        {
            lock (locker)
            {
                if (database.Table<Test>().Count() == 0) return null;
                else
                {
                    var user = database.Table<User>().First(x => x.Id == id);
                    return user.Tests;
                }
            }
        }

        public List<Test> Get10BestScores()
        {
            lock (locker)
            {
                if (database.Table<Test>().Count() == 0) return null;
                else
                {
                    return database.GetAllWithChildren<Test>().OrderBy(x=>x.Score).Take(10).ToList();
                }
            }
        }

        public void Generate10RandomQuestions(int id)
        {
            lock (locker)
            {
                if (database.Table<Test>().Count() == 0) return;
                else
                {
                    var questions = database.GetAllWithChildren<Question>().OrderBy(x => Guid.NewGuid()).Take(15).ToList();
                    var test = database.GetWithChildren<Test>(id);
                    test.Questions = questions;
                    database.UpdateWithChildren(test);
                }
            }
        }

        public float GetUserAverageScore(int id)
        {
            lock (locker)
            {
                if (database.Table<Test>().Count() == 0) return 0;
                else
                {
                    var user = database.Table<User>().First(x => x.Id == id);
                    var tests = user.Tests;
                    return (tests.Select(x => x.Score).Sum()) / tests.Count * 10;
                }
            }
        }

        public Test CreateTest(int score, int userId)
        {
            lock (locker)
            {
                database.Insert(new Test(score, userId));
            }
            return database.Table<Test>().Last();
        }
    }
}
