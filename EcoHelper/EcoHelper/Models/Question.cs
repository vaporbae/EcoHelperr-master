using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace EcoHelper.Models
{
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string QuestionText { get; set; }

        [ManyToMany(typeof(TestQuestion))]
        public List<Test> Tests { get; set; }

        [OneToMany]
        public List<Answer> Answers { get; set; }

        public Question() { }
        public Question(string questionText)
        {
            this.QuestionText = questionText;
            this.Tests = new List<Test>();
            this.Answers = new List<Answer>();

        }
    }
}
