using SQLite;
using SQLiteNetExtensions.Attributes;

namespace EcoHelper.Models
{
    public class Answer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }

        [ForeignKey(typeof(Question))]
        public int QuestionId { get; set; }

        public Answer() { }
        public Answer(string answerText, bool isCorrect, int questionId)
        {
            this.AnswerText = answerText;
            this.IsCorrect = isCorrect;
            this.QuestionId = questionId;
        }
    }
}
