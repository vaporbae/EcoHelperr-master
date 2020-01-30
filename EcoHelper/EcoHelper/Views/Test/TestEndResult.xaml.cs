﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views.Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestEndResult : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        public TestEndResult(Models.Test test, Models.User user)
        {
            InitializeComponent();

            UserName.Text = user.Name;
            ResultText.Text = "Wynik testu: " + test.Score + "/7";
        }

        private void onGoBackClicked(object sender, EventArgs e)
        {
            RootPage.Navigation.PushModalAsync(new MainPage());
        }

        private void onResultsClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TestResultsView());
        }
    }
}