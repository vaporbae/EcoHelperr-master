using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views.Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestMainView : ContentPage
    {
        public TestMainView()
        {
            InitializeComponent();
        }

        private void onStartTestClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TestUserName());
        }

        private void onResultsClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TestResultsView());
        }
    }
}