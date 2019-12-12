using EcoHelper.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace EcoHelper.Data
{
    public class AnswerDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public AnswerDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Answer>();
        }

        public Answer GetAnswer(int id)
        {
            lock (locker)
            {
                if (database.Table<Answer>().Count() == 0) return null;
                else return database.Table<Answer>().FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Answer> GetAnswers()
        {
            lock (locker)
            {
                if (database.Table<Answer>().Count() == 0) return null;
                else return database.Table<Answer>().ToList();
            }
        }

        public bool CheckIfCorrectAnswer(int id)
        {
            lock (locker)
            {
                if (database.Table<Answer>().Count() == 0) return false;
                else
                {
                    var answer = database.Table<Answer>().First(x => x.Id == id);
                    return answer.IsCorrect;
                }
            }
        }

        public Answer CreateAnswer(string answerText, bool isCorrect, int questionId)
        {
            lock (locker)
            {
                database.Insert(new Answer(answerText, isCorrect, questionId));
            }
            return database.Table<Answer>().Last();
        }
    }
}
