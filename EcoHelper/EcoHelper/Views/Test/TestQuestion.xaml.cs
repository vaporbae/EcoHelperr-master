using EcoHelper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views.Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestQuestion : ContentPage
    {
        TestDatabaseController dbTest;
        QuestionDatabaseController dbQuestion;
        List<Models.Question> questions;
        List<Models.Answer> answers;
        int score;

        int id;
        public TestQuestion(Models.User user)
        {
            dbTest = new TestDatabaseController();
            dbQuestion = new QuestionDatabaseController();

            var t = dbTest.CreateTest(0, user.Id);
            dbTest.Generate10RandomQuestions(t.Id);
            var id = t.Id;
            t = dbTest.GetTest(id);
            questions = t.Questions;

            answers = questions[0].Answers;

            score = 0;
            id = 0;
            InitializeComponent();
        }

        private void onAnswer1Clicked(object sender, EventArgs e)
        {
            id++;

            if (answers[0].IsCorrect == true)
            {
                answer1Button.BackgroundColor = Color.ForestGreen;
                Thread.Sleep(1000);
                answer1Button.BackgroundColor = Color.MediumPurple;
                score++;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {

                    answer2Button.BackgroundColor = Color.DarkRed;

                    int correctId = 0;
                    foreach (Models.Answer a in answers)
                    {
                        if (a.IsCorrect == true)
                            break;
                        correctId++;
                    }
                    switch (correctId)
                    {
                        case 1:
                            answer1Button.BackgroundColor = Color.ForestGreen;
                            Thread.Sleep(250);
                            answer1Button.BackgroundColor = Color.MediumPurple;
                            break;
                        case 2:
                            answer2Button.BackgroundColor = Color.ForestGreen;
                            Thread.Sleep(250);
                            answer2Button.BackgroundColor = Color.MediumPurple;
                            break;
                        case 3:
                            answer3Button.BackgroundColor = Color.ForestGreen;
                            Thread.Sleep(250);
                            answer3Button.BackgroundColor = Color.MediumPurple;
                            break;
                        case 4:
                            answer4Button.BackgroundColor = Color.ForestGreen;
                            Thread.Sleep(250);
                            answer4Button.BackgroundColor = Color.MediumPurple;
                            break;
                    }

                }
                answer1Button.BackgroundColor = Color.MediumPurple;
            }

            answers = questions[id].Answers;
        }

        private void onAnswer2Clicked(object sender, EventArgs e)
        {
            id++;

            if (answers[1].IsCorrect == true)
            {
                answer2Button.BackgroundColor = Color.ForestGreen;
                Thread.Sleep(1000);
                answer2Button.BackgroundColor = Color.MediumPurple;
                score++;
            }
            else
            {
                for(int i = 0; i < 4; i++)
                {

                    answer2Button.BackgroundColor = Color.DarkRed;

                    int correctId = 0;
                    foreach (Models.Answer a in answers)
                    {
                        if (a.IsCorrect == true)
                            break;
                        correctId++;
                    }
                    switch (correctId)
                    {
                        case 1:
                            answer1Button.BackgroundColor = Color.ForestGreen;
                            Thread.Sleep(250);
                            answer1Button.BackgroundColor = Color.MediumPurple;
                            break;
                        case 2:
                            answer2Button.BackgroundColor = Color.ForestGreen;
                            Thread.Sleep(250);
                            answer2Button.BackgroundColor = Color.MediumPurple;
                            break;
                        case 3:
                            answer3Button.BackgroundColor = Color.ForestGreen;
                            Thread.Sleep(250);
                            answer3Button.BackgroundColor = Color.MediumPurple;
                            break;
                        case 4:
                            answer4Button.BackgroundColor = Color.ForestGreen;
                            Thread.Sleep(250);
                            answer4Button.BackgroundColor = Color.MediumPurple;
                            break;
                    }

                }
                answer2Button.BackgroundColor = Color.MediumPurple;
            }

            answers = questions[id].Answers;

        }

        private void onAnswer3Clicked(object sender, EventArgs e)
        {
            id++;

            if (answers[2].IsCorrect == true)
            {
                answer3Button.BackgroundColor = Color.ForestGreen;
                Thread.Sleep(1000);
                answer3Button.BackgroundColor = Color.MediumPurple;
                score++;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {

                    answer3Button.BackgroundColor = Color.DarkRed;

                    int correctId = 0;
                    foreach (Models.Answer a in answers)
                    {
                        if (a.IsCorrect == true)
                            break;
                        correctId++;
                    }
                    switch (correctId)
                    {
                        case 1:
                            answer1Button.BackgroundColor = Color.ForestGreen;
                            Thread.Sleep(250);
                            answer1Button.BackgroundColor = Color.MediumPurple;
                            break;
                        case 2:
                            answer2Button.BackgroundColor = Color.ForestGreen;
                            Thread.Sleep(250);
                            answer2Button.BackgroundColor = Color.MediumPurple;
                            break;
                        case 3:
                            answer3Button.BackgroundColor = Color.ForestGreen;
                            Thread.Sleep(250);
                            answer3Button.BackgroundColor = Color.MediumPurple;
                            break;
                        case 4:
                            answer4Button.BackgroundColor = Color.ForestGreen;
                            Thread.Sleep(250);
                            answer4Button.BackgroundColor = Color.MediumPurple;
                            break;
                    }

                }
                answer3Button.BackgroundColor = Color.MediumPurple;
            }

            answers = questions[id].Answers;
        }

        private void onAnswer4Clicked(object sender, EventArgs e)
        {
            id++;

            if (answers[3].IsCorrect == true)
            {
                answer4Button.BackgroundColor = Color.ForestGreen;
                Thread.Sleep(1000);
                answer4Button.BackgroundColor = Color.MediumPurple;
                score++;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {

                    answer4Button.BackgroundColor = Color.DarkRed;

                    int correctId = 0;
                    foreach (Models.Answer a in answers)
                    {
                        if (a.IsCorrect == true)
                            break;
                        correctId++;
                    }
                    switch (correctId)
                    {
                        case 1:
                            answer1Button.BackgroundColor = Color.ForestGreen;
                            Thread.Sleep(250);
                            answer1Button.BackgroundColor = Color.MediumPurple;
                            break;
                        case 2:
                            answer2Button.BackgroundColor = Color.ForestGreen;
                            Thread.Sleep(250);
                            answer2Button.BackgroundColor = Color.MediumPurple;
                            break;
                        case 3:
                            answer3Button.BackgroundColor = Color.ForestGreen;
                            Thread.Sleep(250);
                            answer3Button.BackgroundColor = Color.MediumPurple;
                            break;
                        case 4:
                            answer4Button.BackgroundColor = Color.ForestGreen;
                            Thread.Sleep(250);
                            answer4Button.BackgroundColor = Color.MediumPurple;
                            break;
                    }

                }
                answer4Button.BackgroundColor = Color.MediumPurple;
            }

            answers = questions[id].Answers;
        }
    }
}