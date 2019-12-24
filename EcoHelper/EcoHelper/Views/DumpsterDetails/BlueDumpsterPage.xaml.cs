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
    public partial class BlueDumpsterPage : ContentPage
    {
        public BlueDumpsterPage()
        {
            InitializeComponent();
            onWhatToThrowClicked(new Xamarin.Forms.Button(), new System.EventArgs());
        }

        private void onWhatToThrowClicked(object sender, EventArgs e)
        {
            ToThrowBox.BackgroundColor = Color.DarkGreen;
            ThrowLabel.Text = "\nOpakowania z papieru\nKarton\nTektura\nKatalogi\nUlotki\nGazety i czasopisma\nPapier szkolny i biurowy\nZeszyty i książki\nPapier pakowy\nTorby i worki papierowe\n";
            ToNotThrowBox.BackgroundColor = Color.FromHex("#D93437");
        }

        private void onWhatNotToThrowClicked(object sender, EventArgs e)
        {
            ToNotThrowBox.BackgroundColor = Color.DarkRed;
            ThrowLabel.Text = "\nRęczniki papierowe i zużyte chusteczki\nPapier lakierowany\nPapier zatłuszczony lub mocno zabrudzony\nKartony po mleku i napojach\nPapierowe worki po nawozach, cemencie i innych materiałach budowlanych\nTapety\nPieluchy\nUbrania\n";
            ToThrowBox.BackgroundColor = Color.FromHex("#13CE66");
        }

        private void onWhereToThrowAwayClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WhereToThrowSearch());
        }
    }
}