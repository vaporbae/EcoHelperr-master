using EcoHelper.Data;
using EcoHelper.Models;
using EcoHelper.Views.WhereToThrow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views.DumpsterDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GreyWastePage : ContentPage
    {
        int DisplayedTips;
        List<InterestingFact> interestingFacts;
        DumpsterDatabaseController dumpsterDatabaseController;
        Dumpster dumpster;
        InterestingFact displayedInterestingFact;
        public GreyWastePage()
        {
            DisplayedTips = 0;
            interestingFacts = new List<InterestingFact>();
            dumpsterDatabaseController = new DumpsterDatabaseController();

            dumpster = dumpsterDatabaseController.SearchDumpster("szary");
            interestingFacts = dumpster.InterestingFacts;

            displayedInterestingFact = GetRandomTip();

            InitializeComponent();
            DisplayTip();
            onWhatToThrowClicked(new Xamarin.Forms.Button(), new System.EventArgs());
        }

        private void onWhatToThrowClicked(object sender, EventArgs e)
        {
            ToThrowBox.BackgroundColor = Color.DarkGreen;
            ThrowLabel.Text = "\nPopiół\nŻużel\n";
            ToNotThrowBox.BackgroundColor = Color.FromHex("#D93437");
        }

        private void onWhatNotToThrowClicked(object sender, EventArgs e)
        {
            ToNotThrowBox.BackgroundColor = Color.DarkRed;
            ThrowLabel.Text = "\nPiasek\n";
            ToThrowBox.BackgroundColor = Color.FromHex("#13CE66");
        }

        private void onWhereToThrowAwayClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WhereToThrowSearch());
        }
        private void onShowOtherTipClicked(object sender, EventArgs e)
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
                TipLabelTitleGrid.IsVisible = true;
                TipLabelGrid.IsVisible = true;
                TipLabel.Text = displayedInterestingFact.Description;
                OtherTipGrid.IsVisible = true;
            }
            else if (displayedInterestingFact == null && DisplayedTips > 0)
            {
                TipLabelTitleGrid.IsVisible = true;
                TipLabelGrid.IsVisible = true;
                TipLabel.Text = "Nie posiadam więcej ciekawostek na ten temat";
                OtherTipGrid.IsVisible = false;
            }
            else
            {
                TipLabelTitleGrid.IsVisible = false;
                TipLabelGrid.IsVisible = false;
                OtherTipGrid.IsVisible = false;
            }
        }
    }
}