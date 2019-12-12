using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace EcoHelper.Models
{
    public class Dumpster
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }
        [OneToMany]
        public List<Garbage> Garbages { get; set; }
        [OneToMany]
        public List<InterestingFact> InterestingFacts { get; set; }

        public Dumpster() { }
        public Dumpster(string name)
        {
            this.Name = name;
            this.Garbages = new List<Garbage>();
            this.InterestingFacts = new List<InterestingFact>();
        }
    }
}
