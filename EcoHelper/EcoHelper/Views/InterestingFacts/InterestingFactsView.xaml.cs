using EcoHelper.Data;
using EcoHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views.InterestingFacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InterestingFactsView : ContentPage
    {
        int DisplayedTips;
        List<InterestingFact> interestingFacts;
        InterestingFactDatabaseController interestingFactDatabaseController;
        InterestingFact displayedInterestingFact;
        public InterestingFactsView()
        {
            DisplayedTips = 0;
            interestingFacts = new List<InterestingFact>();
            interestingFactDatabaseController = new InterestingFactDatabaseController();

            interestingFacts = interestingFactDatabaseController.GetInterestingFacts();

            displayedInterestingFact = GetRandomTip();
            InitializeComponent();

            DisplayTip();
        }

        private void onNextTextClicked(object sender, EventArgs e)
        {
            displayedInterestingFact = GetRandomTip();
            DisplayTip();
        }


        private InterestingFact GetRandomTip()
        {
            var interestingFact = interestingFacts.FirstOrDefault();
            if (interestingFact != default)
            {
                interestingFacts.Remove(interestingFact);
                DisplayedTips++;
                return interestingFact;
            }
            else
                return null;
        }

        private void DisplayTip()
        {
            if (displayedInterestingFact != null)
            {
                LabelText.Text = displayedInterestingFact.Description;
                NextTipButton.IsVisible = true;
            }
            else if (displayedInterestingFact == null && DisplayedTips > 0)
            {
                LabelText.Text = "Nie posiadam więcej ciekawostek.";
                NextTipButton.BackgroundColor = Color.Gray;
            }
            else
            {
                LabelText.Text = "Nie posiadam żadnych ciekawostek.";
                NextTipButton.BackgroundColor = Color.Gray;
            }
        }
    }
}