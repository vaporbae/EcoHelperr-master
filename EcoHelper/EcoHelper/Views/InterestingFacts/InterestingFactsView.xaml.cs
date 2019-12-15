using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views.InterestingFacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InterestingFactsView : ContentPage
    {
        public InterestingFactsView()
        {
            InitializeComponent();
        }

        private void onNextTextClicked(object sender, EventArgs e)
        {
        }
    }
}