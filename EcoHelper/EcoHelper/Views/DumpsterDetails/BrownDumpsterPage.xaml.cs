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
    public partial class BrownDumpsterPage : ContentPage
    {
        public BrownDumpsterPage()
        {
            InitializeComponent();
            onWhatToThrowClicked(new Xamarin.Forms.Button(), new System.EventArgs());
        }

        private void onWhatToThrowClicked(object sender, EventArgs e)
        {
            ToThrowBox.BackgroundColor = Color.DarkGreen;
            ThrowLabel.Text = "\nOdpadki warzywne i owocowe\nGałęzie drzew i krzewów\nSkoszoną trawę, liście, kwiaty\nTrociny i korę drzew\nNiezaimpregnowane drewno\nResztki jedzenia\n";
            ToNotThrowBox.BackgroundColor = Color.FromHex("#D93437");
        }

        private void onWhatNotToThrowClicked(object sender, EventArgs e)
        {
            ToNotThrowBox.BackgroundColor = Color.DarkRed;
            ThrowLabel.Text = "\nKości zwierząt\nOlej jadalny\nOdchody zwierząt\nPopiół z węgla kamiennego\nLeki\nDrewno impregnowane\nPłyty wiórowe i pilśniowe MDF\nZiemia i kamienie\nInne odpady komunalne\n";
            ToThrowBox.BackgroundColor = Color.FromHex("#13CE66");
        }

        private void onWhereToThrowAwayClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WhereToThrowSearch());
        }
    }
}