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
    public partial class BulkyWastePage : ContentPage
    {
        public BulkyWastePage()
        {
            InitializeComponent();
            onWhatToThrowClicked(new Xamarin.Forms.Button(), new System.EventArgs());
        }

        private void onWhatToThrowClicked(object sender, EventArgs e)
        {
            ToThrowBox.BackgroundColor = Color.DarkGreen;
            ThrowLabel.Text = "\nStare meble\nMaterace\nDywany\nWykładziny\nDeski do prasowania\nDuże lustra (w ramie)\nDuże instrumenty muzyczne\nWóżki\nKojce dla dzieci\nRowery\nDeski meblowe\nKarnisze\nDuże zabawki bez elektroniki\nUmywalki\nZlewozmywaki\nKabina prysznicowa\nWanna\nBrodzik od prysznica\nMeble ogrodowe\nPojedyncze skrzydło drzwi lub okna (bez futryny, ościeżnic, parapetów)\n";
            ToNotThrowBox.BackgroundColor = Color.FromHex("#D93437");
        }

        private void onWhatNotToThrowClicked(object sender, EventArgs e)
        {
            ToNotThrowBox.BackgroundColor = Color.DarkRed;
            ThrowLabel.Text = "\nOdpady budowlane i remontowe\nOdpady niebezpieczne, np. Farby lakiery\nOdpady Samochodowe\nMniejszy sprzęt elektroniczny\n";
            ToThrowBox.BackgroundColor = Color.FromHex("#13CE66");
        }

        private void onWhereToThrowAwayClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WhereToThrowSearch());
        }
    }
}