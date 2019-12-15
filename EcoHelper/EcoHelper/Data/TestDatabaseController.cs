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
                return database.GetWithChildren<Test>(id);
            }
        }

        public List<Test> GetTests()
        {
            lock (locker)
            {
                if (database.Table<Test>().Count() == 0) return null;
                return database.GetAllWithChildren<Test>();
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
                    return database.GetAllWithChildren<Test>().OrderByDescending(x=>x.Score).Take(10).ToList();
                }
            }
        }

        public void Generate7RandomQuestions(int id)
        {
            lock (locker)
            {
                if (database.Table<Test>().Count() == 0) return;
                else
                {
                    var questions = database.GetAllWithChildren<Question>().OrderBy(x => Guid.NewGuid()).Take(7);
                    var test = database.GetWithChildren<Test>(id);
                    test.Questions.AddRange(questions);
                    database.UpdateWithChildren(test);
                }
            }
        }

        public void SetScore(int id, int score)
        {
            lock (locker)
            {
                if (database.Table<Test>().Count() == 0) return;
                else
                {
                    var test = database.GetWithChildren<Test>(id);
                    test.Score = score;
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
