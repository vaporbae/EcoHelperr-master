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
    public partial class TireWastePage : ContentPage
    {
        int DisplayedTips;
        List<InterestingFact> interestingFacts;
        DumpsterDatabaseController dumpsterDatabaseController;
        Dumpster dumpster;
        InterestingFact displayedInterestingFact;
        public TireWastePage()
        {
            DisplayedTips = 0;
            interestingFacts = new List<InterestingFact>();
            dumpsterDatabaseController = new DumpsterDatabaseController();

            dumpster = dumpsterDatabaseController.SearchDumpster("stacje demonta");
            interestingFacts = dumpster.InterestingFacts;

            displayedInterestingFact = GetRandomTip();

            InitializeComponent();
            DisplayTip();
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