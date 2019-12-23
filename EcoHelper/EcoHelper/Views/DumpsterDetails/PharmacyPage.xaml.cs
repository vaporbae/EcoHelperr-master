using EcoHelper.Views.DumpsterDetails.PharmacyPages;
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
    public partial class PharmacyPage : ContentPage
    {
        public PharmacyPage()
        {
            InitializeComponent();
            onWhatToThrowClicked(new Xamarin.Forms.Button(),new System.EventArgs());
        }

        private void onWhatToThrowClicked(object sender, EventArgs e)
        {
            ToThrowBox.BackgroundColor = Color.DarkGreen;
            ThrowLabel.Text = "\nPrzeterminowane leki\nNieuszukodzone termometry\nzastrzyki w ampułkach\nsuplementy diety\n";
            ToNotThrowBox.BackgroundColor = Color.FromHex("#D93437");
        }

        private void onWhatNotToThrowClicked(object sender, EventArgs e)
        {
            ToNotThrowBox.BackgroundColor = Color.DarkRed;
            ThrowLabel.Text = "\nPapierowe opakowania\nUszukodzone termometry\nStrzykawek i igieł\n";
            ToThrowBox.BackgroundColor = Color.FromHex("#13CE66");
        }

        private void onSearchForPharmaciesClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PharmaciesAddressPage());
        }

    }
}