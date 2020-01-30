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
    public partial class AuthorisedEntityPage : ContentPage
    {
        public AuthorisedEntityPage()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.Content = null;
            GC.Collect();
        }
    }
}