using SQLite;

namespace EcoHelper.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
        //void DeletePolls();
    }
}
