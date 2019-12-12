using SQLite;
using System;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace EcoHelper.Models
{
    public class Test
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey(typeof(User))]
        public int UserId { get; set; }

        [ManyToMany(typeof(TestQuestion))]
        public List<Question> Questions { get; set; }

        public Test() { }
        public Test(int score, int userId)
        {
            this.Score = score;
            this.UserId = userId;
            this.CreatedAt = DateTime.UtcNow;
            this.Questions = new List<Question>();

        }

    }
}
