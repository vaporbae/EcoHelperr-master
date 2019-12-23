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
            
        }
        private void onSearchForPharmaciesClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PharmaciesAddressPage());
        }

    }
}