using System.IO;
using EcoHelper.Data;
using EcoHelper.Droid.Data;
using Xamarin.Forms;
[assembly: Dependency(typeof(SQLite_Android))]

namespace EcoHelper.Droid.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "EcoHelperDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}