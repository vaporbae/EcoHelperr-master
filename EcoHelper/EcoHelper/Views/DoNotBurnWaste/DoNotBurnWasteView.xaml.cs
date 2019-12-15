using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views.DoNotBurnWaste
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoNotBurnWasteView : ContentPage
    {
        public DoNotBurnWasteView()
        {
            InitializeComponent();
            LabelText.Text = "W czasie spalania śmieci powstają substancje, które mają silne działanie rakotwórcze i śmiercionośne.";
        }

        private void onGoLeftClicked(object sender, EventArgs e)
        {
        }

        private void onGoRightClicked(object sender, EventArgs e)
        {
        }
    }
}