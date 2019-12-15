using EcoHelper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views.Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestResultsView : ContentPage
    {
        List<Models.Test> Scores;
        TestDatabaseController dbTest;
        UserDatabaseController dbUser;
        List<ResultItem> ScoresList;
        public TestResultsView()
        {
            dbTest = new TestDatabaseController();
            dbUser = new UserDatabaseController();
            Scores = dbTest.Get10BestScores();
            ScoresList = new List<ResultItem>();

            int i = 0;
            foreach(Models.Test test in Scores)
            {
                i++;
                var user = dbUser.GetUser(test.UserId);
                ScoresList.Add(new ResultItem { Text = i + ". " + user.Name + " - " + test.Score });
            }

            ScoresListView.ItemsSource = ScoresList;

            InitializeComponent();
        }

        private void onStartTestClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TestUserName());
        }
    }

    public class ResultItem
    {
        public string Text { get; set; }
    }
}