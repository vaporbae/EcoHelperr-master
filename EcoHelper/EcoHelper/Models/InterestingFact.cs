using SQLite;
using SQLiteNetExtensions.Attributes;

namespace EcoHelper.Models
{
    public class InterestingFact
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey(typeof(Dumpster))]
        public int? DumpsterId { get; set; }

        public InterestingFact() { }
        public InterestingFact(string title, string description, int? dumpsterId)
        {
            this.Title = title;
            this.Description = description;
            this.DumpsterId = dumpsterId;
        }
    }
}
