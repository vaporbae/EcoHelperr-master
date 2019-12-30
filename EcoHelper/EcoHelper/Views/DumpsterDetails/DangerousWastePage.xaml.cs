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
        public DangerousWastePage()
        {
            InitializeComponent();
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

    }
}