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
    public partial class BatteriesWastePage : ContentPage
    {
        public BatteriesWastePage()
        {
            InitializeComponent();
        }

        private void onWhereToThrowAwayClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WhereToThrowSearch());
        }
    }
}