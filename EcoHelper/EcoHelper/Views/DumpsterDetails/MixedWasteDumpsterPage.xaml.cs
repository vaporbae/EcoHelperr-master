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
    public partial class MixedWasteDumpsterPage : ContentPage
    {
        public MixedWasteDumpsterPage()
        {
            InitializeComponent();
            onWhatToThrowClicked(new Xamarin.Forms.Button(), new System.EventArgs());
        }

        private void onWhatToThrowClicked(object sender, EventArgs e)
        {
            ToThrowBox.BackgroundColor = Color.DarkGreen;
            ThrowLabel.Text = "\nGąbki\nKurz z odkurzacza\nMaszynki do golenia\nNiedopałki papierosów\nOlej do smażenia\nParagony\nPergamin\nPiasek\nPlastikowe opakowania po tłuszczu\nPorcelana\nProdukty higieniczne\nProdukty skórzane, futrzane\nTorebki po herbacie\nWłosy, sierść, pióra\nZatłuszczony papier\nPusta zapalniczka\nŻwirek, trociny\n";
            ToNotThrowBox.BackgroundColor = Color.FromHex("#D93437");
        }

        private void onWhatNotToThrowClicked(object sender, EventArgs e)
        {
            ToNotThrowBox.BackgroundColor = Color.DarkRed;
            ThrowLabel.Text = "\nOdpady wielkogabarytowe\nOdpady budowlane i rozbiórkowe\nZużyte opony\nBaterie i akumulatory\nLekarstwa\nOdpady medyczne\nŚwietlówki\nOpakowania po środkach ochrony roślin\nZużyty sprzęt elektryczny i elektroniczny\n";
            ToThrowBox.BackgroundColor = Color.FromHex("#13CE66");
        }

        private void onWhereToThrowAwayClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WhereToThrowSearch());
        }
    }
}