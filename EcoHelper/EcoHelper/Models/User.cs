using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoHelper.Models
{
    public class User
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public float AverageTestScore { get; set; }

        [OneToMany]
        public List<Test> Tests { get; set; }

        public User() { }
        public User(string name, bool isNew = true)
        {
            this.Name = name;
            if(isNew == true)
            {
                this.CreatedAt = DateTime.UtcNow;
            }
        }
    }
}
