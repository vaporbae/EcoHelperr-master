using SQLite;
using SQLiteNetExtensions.Attributes;

namespace EcoHelper.Models
{
    public class Garbage
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }

        [ForeignKey(typeof(Dumpster))]
        public int DumpsterId { get; set; }

        public Garbage() { }
        public Garbage(string name, int dumpsterId)
        {
            this.Name = name;
            this.DumpsterId = dumpsterId;
        }
    }
}
