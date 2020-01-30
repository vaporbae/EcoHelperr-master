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
        public GreyWastePage()
        {
            InitializeComponent();
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
    }
}