using SQLite;
using SQLiteNetExtensions.Attributes;

namespace EcoHelper.Models
{
    public class DatabaseVersion
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Ver { get; set; }

        public DatabaseVersion() { }
        public DatabaseVersion(double ver)
        {
            this.Ver = ver;
        }
    }
}
