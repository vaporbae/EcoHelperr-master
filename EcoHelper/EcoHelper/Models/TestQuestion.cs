using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoHelper.Models
{
    public class TestQuestion
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Test))]
        public int TestId { get; set; }

        [ForeignKey(typeof(Question))]
        public int QuestionId { get; set; }
    }
}
