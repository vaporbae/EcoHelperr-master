using EcoHelper.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace EcoHelper.Data
{
    public class UserDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<User>();
        }

        public void ResetTable()
        {
            database.DropTable<User>();
            database.CreateTable<User>();
        }

        public User GetUser(int id)
        {
            lock (locker)
            {
                if (database.Table<User>().Count() == 0) return null;
                else return database.GetWithChildren<User>(id);
            }
        }

        public List<User> GetUsers()
        {
            lock(locker)
            {
                if (database.Table<User>().Count() == 0) return null;
                else return database.GetAllWithChildren<User>();
            }
        }

        public void UpdateUser (int id, string name)
        {
            lock (locker)
            {
                var user = GetUser(id);
                if (user == null) return;

                user.Name = name;
                database.Update(user);
            }
        }

        public User CreateUser (string name)
        {
            lock (locker)
            {
                database.Insert(new User(name));
            }
            return database.Table<User>().Last();
        }

        public void DeleteUser (int id)
        {
            database.Delete<User>(id);
        }
    }
}
