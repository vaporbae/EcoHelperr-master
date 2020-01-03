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
        public const string BasicURL = "https://eco-helper.azurewebsites.net/api";

        DumpsterDatabaseController dbDumpster;
        GarbageDatabaseController dbGarbage;
        QuestionDatabaseController dbQuestion;
        AnswerDatabaseController dbAnswer;
        InterestingFactDatabaseController dbInterestingFacts;
        TestDatabaseController dbTests;

        WebInterface webInterface;
        public UpdateDatabase() { }
        public async Task<bool> UpdateAsync()
        {
            try
            {
                dbDumpster = new DumpsterDatabaseController();
                dbGarbage = new GarbageDatabaseController();

                dbTests = new TestDatabaseController();

                dbQuestion = new QuestionDatabaseController();
                dbAnswer = new AnswerDatabaseController();

                dbInterestingFacts = new InterestingFactDatabaseController();

                

                dbGarbage.ResetTable();
                dbDumpster.ResetTable();
                dbAnswer.ResetTable();
                dbQuestion.ResetTable();
                dbInterestingFacts.ResetTable();

                webInterface = new WebInterface(new System.Net.Http.HttpClient());

                var dumpsterReqString = await webInterface.MakeGetRequest(BasicURL + "/dumpsters");
                var garbageReqString = await webInterface.MakeGetRequest(BasicURL + "/garbages");
                var interestingFactsReqString = await webInterface.MakeGetRequest(BasicURL + "/interestingfacts");

                var dumpsters = JsonConvert.DeserializeObject<DumpstersList>(dumpsterReqString.ToString()) ;
                var garbages = JsonConvert.DeserializeObject<GarbageList>(garbageReqString);
                var interestingFacts = JsonConvert.DeserializeObject<InterestingFactsList>(interestingFactsReqString);

                foreach (Dumpster dumpster in dumpsters.Dumpsters)
                {
                    dbDumpster.CreateDumpster(dumpster.Name);
                }

                foreach (Garbage garbage in garbages.Garbages)
                {
                    var g = dbGarbage.CreateGarbage(garbage.Name, garbage.DumpsterId);
                    dbDumpster.AddGarbage(g, g.DumpsterId);
                }

                foreach (InterestingFact interestingFact in interestingFacts.InterestingFacts)
                {
                    var iF = dbInterestingFacts.CreateInterestingFact("", interestingFact.Description, interestingFact.DumpsterId);
                    var DumpsterId = interestingFact.DumpsterId == null ? -1 : interestingFact.DumpsterId;
                    if (DumpsterId != -1) dbDumpster.AddInterestingFact(iF, DumpsterId);
                }

                var questionReqString = await webInterface.MakeGetRequest(BasicURL + "/questions");
                var answerReqString = await webInterface.MakeGetRequest(BasicURL + "/answers");

                var questions = JsonConvert.DeserializeObject<QuestionsList>(questionReqString);
                var answers = JsonConvert.DeserializeObject<AnswersList>(answerReqString);

                foreach (Question question in questions.Questions)
                {
                    dbQuestion.CreateQuestion(question.QuestionText);
                }

                var q = dbQuestion.GetQuestions();

                foreach (Answer answer in answers.Answers)
                {
                    var g = dbAnswer.CreateAnswer(answer.AnswerText, answer.IsCorrect, answer.QuestionId);
                    dbQuestion.AddAnswer(g, g.QuestionId-1);
                }

                return true;
            }
            catch (Exception e)
            {
                var b = e.Message;
                return false;
            }
        }
    }
}
