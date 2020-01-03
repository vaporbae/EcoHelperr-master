using EcoHelper.Data;
using EcoHelper.Models;
using EcoHelper.Views.DumpsterDetails.PSZOKPages;
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
    public partial class DangerousWastePage : ContentPage
    {
        int DisplayedTips;
        List<InterestingFact> interestingFacts;
        DumpsterDatabaseController dumpsterDatabaseController;
        Dumpster dumpster;
        Dumpster dumpster2;
        InterestingFact displayedInterestingFact;
        public DangerousWastePage()
        {
            DisplayedTips = 0;
            interestingFacts = new List<InterestingFact>();
            dumpsterDatabaseController = new DumpsterDatabaseController();

            dumpster = dumpsterDatabaseController.SearchDumpster("chemikalia");
            dumpster2 = dumpsterDatabaseController.SearchDumpster("punkt selektywnego");
            interestingFacts = dumpster.InterestingFacts;
            interestingFacts.AddRange(dumpster2.InterestingFacts);

            displayedInterestingFact = GetRandomTip();

            InitializeComponent();
            DisplayTip();
            onWhatToThrowClicked(new Xamarin.Forms.Button(), new System.EventArgs());
        }

        private void onWhatToThrowClicked(object sender, EventArgs e)
        {
            ToThrowBox.BackgroundColor = Color.DarkGreen;
            ThrowLabel.Text = "\nOpakowania po olejach silnikowych, detergentach, środkach ochrony roślin\nPojemniki pod ciśnieniem w aerozolach\nGaśnice\nOpony pojazdów\nOdpady z betonu\nGruz\nCeramika\nGlazura\nTerakota\nLustra\nSzkło okienne\nRozpuszczalniki\nKwasy\nAlkalia\nOdczynniki fotograficzne\nŚrodki ochrony roślin\nOleje i tłuszcze\nOleje silnikowe\nFarby\nKleje\nTusze i tonery do drukarek\nLepiszcze i żywice (też te zawierające niebezpieczne subtancje)\nDetergenty\nDrewno zawierajce subtancje niebezpieczne\nDrewno\nMeble\nRamy rowerowe\nLampy fluorescencyjne\nŚwietlówki\nLampy energooszczędne\nTermometry rtęciowe\nUrządzenia chłodnicze i klimatyzacyjne\nZużyte urządzenia elektryczne i elektroniczne\nAkumulatory\nBaterie\nLeki\nOdpady wielkogabarytowe\n";
            ToNotThrowBox.BackgroundColor = Color.FromHex("#D93437");
        }

        private void onWhatNotToThrowClicked(object sender, EventArgs e)
        {
            ToNotThrowBox.BackgroundColor = Color.DarkRed;
            ThrowLabel.Text = "\nNiesegregowane zmieszane odpady komunalne\nMateriały zawierające azbest\nPapa i styropian budowlany\nOdpadny w opakowaniach cieknących\nInne odpady wymagające odbioru przez uprawniony podmiot\n";
            ToThrowBox.BackgroundColor = Color.FromHex("#13CE66");
        }

        private void onSearchForPharmaciesClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PSZOKAddressPage());
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