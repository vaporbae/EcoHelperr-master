using EcoHelper.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace EcoHelper.Data
{
    public class QuestionDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public QuestionDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Question>();
        }

        public void ResetTable()
        {
            database.DropTable<Question>();
            database.CreateTable<Question>();
        }

        public void AddAnswer(Answer answer, int id)
        {
            lock (locker)
            {
                var Question = database.GetWithChildren<Question>(id);
                Question.Answers.Add(answer);
                database.UpdateWithChildren(Question);
            }
        }

        public Question GetQuestion(int id)
        {
            lock (locker)
            {
                return database.GetWithChildren<Question>(id);
            }
        }

        public List<Question> GetQuestions()
        {
            lock (locker)
            {
                return database.GetAllWithChildren<Question>();
            }
        }

        public Question CreateQuestion(string questionText)
        {
            lock (locker)
            {
                database.Insert(new Question(questionText));
            }
            return database.Table<Question>().Last();
        }
    }
}
