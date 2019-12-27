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
    public partial class ConstructionWastePage : ContentPage
    {
        public ConstructionWastePage()
        {
            InitializeComponent();
            onWhatToThrowClicked(new Xamarin.Forms.Button(), new System.EventArgs());
        }

        private void onWhatToThrowClicked(object sender, EventArgs e)
        {
            ToThrowBox.BackgroundColor = Color.DarkGreen;
            ThrowLabel.Text = "\nGruz betonowy\nGruz ceglany\nGruz ceramiczny\nUsunięty tynk\nGips\nCement\nPłyty kartonowo-gipsowe\nTapety\nStolarka okienna i drzwiowa\nOdpady instalacyjne\nMateriały pokryć dachowych\nElementy Ceramiki\nInstalacje metalowe i PVC\nZłom\nStal zbrojeniowa\nOdpady z drewna i tworzyw sztucznych\nMateriały izolacyjne\nStyropian\nGleba i grunt z wykopów\nKleje\nFarby\n";
            ToNotThrowBox.BackgroundColor = Color.FromHex("#D93437");
        }

        private void onWhatNotToThrowClicked(object sender, EventArgs e)
        {
            ToNotThrowBox.BackgroundColor = Color.DarkRed;
            ThrowLabel.Text = "\n\n";
            ToThrowBox.BackgroundColor = Color.FromHex("#13CE66");
        }

        private void onWhereToThrowAwayClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WhereToThrowSearch());
        }
    }
}