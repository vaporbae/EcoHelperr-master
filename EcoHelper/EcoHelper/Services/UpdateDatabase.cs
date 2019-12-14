using EcoHelper.Data;
using EcoHelper.Models;
using EcoHelper.Models.Deserialize;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcoHelper.Services
{
    public class UpdateDatabase
    {
        public const string BasicURL = "http://eco-helper.azurewebsites.net";

        DumpsterDatabaseController dbDumpster;
        GarbageDatabaseController dbGarbage;
        QuestionDatabaseController dbQuestion;
        AnswerDatabaseController dbAnswer;

        WebInterface webInterface;
        public UpdateDatabase() { }
        public Task<bool> UpdateAsync()
        {
            try
            {
                dbDumpster = new DumpsterDatabaseController();
                dbGarbage = new GarbageDatabaseController();

                dbQuestion = new QuestionDatabaseController();
                dbAnswer = new AnswerDatabaseController();

                dbGarbage.ResetTable();
                dbDumpster.ResetTable();
                dbAnswer.ResetTable();
                dbQuestion.ResetTable();

                webInterface = new WebInterface(new System.Net.Http.HttpClient());

                var dumpsterReqString = webInterface.MakeGetRequest(BasicURL + "/dumpsters").ToString();
                var garbageReqString = webInterface.MakeGetRequest(BasicURL + "/garbages").ToString();

                var dumpsters = JsonConvert.DeserializeObject<DumpstersList>(dumpsterReqString);
                var garbages = JsonConvert.DeserializeObject<GarbageList>(garbageReqString);

                foreach (Dumpster dumpster in dumpsters.Dumpsters)
                {
                    dbDumpster.CreateDumpster(dumpster.Name);
                }

                foreach (Garbage garbage in garbages.Garbages)
                {
                    var g = dbGarbage.CreateGarbage(garbage.Name, garbage.DumpsterId);
                    dbDumpster.AddGarbage(g, g.DumpsterId);
                }

                var questionReqString = webInterface.MakeGetRequest(BasicURL + "/questions").ToString();
                var answerReqString = webInterface.MakeGetRequest(BasicURL + "/answers").ToString();

                var questions = JsonConvert.DeserializeObject<QuestionsList>(questionReqString);
                var answers = JsonConvert.DeserializeObject<AnswersList>(answerReqString);

                foreach (Question question in questions.Questions)
                {
                    dbQuestion.CreateQuestion(question.QuestionText);
                }

                foreach (Answer answer in answers.Answers)
                {
                    var g = dbAnswer.CreateAnswer(answer.AnswerText, answer.IsCorrect, answer.QuestionId);
                    dbQuestion.AddAnswer(g, g.QuestionId);
                }


                //RootObject m = JsonConvert.DeserializeObject<RootObject>(yourstring);

                //zrobic request
                //z jsona bezposrednio na grupe ta dac tabele
                //pobrac grupe dumpsterow
                //pobrac grupe garbage
                //w kazdym garbage dodac do dumpstera o odpowiednim id
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }
}
