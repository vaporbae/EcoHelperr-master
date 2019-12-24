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
    public partial class YellowDumpsterPage : ContentPage
    {
        public YellowDumpsterPage()
        {
            InitializeComponent();
            onWhatToThrowClicked(new Xamarin.Forms.Button(), new System.EventArgs());
        }

        private void onWhatToThrowClicked(object sender, EventArgs e)
        {
            ToThrowBox.BackgroundColor = Color.DarkGreen;
            ThrowLabel.Text = "\nOdkręcone i zgniecione plastikowe butelki\nNakrętki, o ile nie zbieramy ich w ramach akcji dobroczynnych\nPlastikowe opakowania po produktach spożywczych\nOpakowania wielomateriałowe (po mleku, sokach)\nOpakowania po środkach czystości\nPuszki po konserwach\nFolia aluminiowa\nMetale kolorowe\nKapsle\nZakrętki od słoików\nPlastikowe torby, worki, reklamówki itp.\n";
            ToNotThrowBox.BackgroundColor = Color.FromHex("#D93437");
        }

        private void onWhatNotToThrowClicked(object sender, EventArgs e)
        {
            ToNotThrowBox.BackgroundColor = Color.DarkRed;
            ThrowLabel.Text = "\nButelek i pojemników z zawartości\nZużyty sprzęt elektroniczny i AGD\nPuszki i pojemniki po farbach i lakierach\nCzęści samochodowe\nOpakowania po olejach silnikowych\nZużyte artykuły medyczne\nPłyty CD i DVD\nAmunicja\n";
            ToThrowBox.BackgroundColor = Color.FromHex("#13CE66");
        }

        private void onWhereToThrowAwayClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WhereToThrowSearch());
        }
    }
}