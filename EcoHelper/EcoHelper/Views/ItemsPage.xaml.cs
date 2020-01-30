using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using EcoHelper.Models;
using EcoHelper.Views;
using EcoHelper.ViewModels;
using EcoHelper.Services;
using EcoHelper.Views.WhereToThrow;
using EcoHelper.Views.Test;
using EcoHelper.Data;

namespace EcoHelper.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        int update;

        public ItemsPage()
        {
            InitializeComponent();

            
            var database = new UpdateDatabase();

            Device.BeginInvokeOnMainThread(async () =>
            {
                update = await database.CheckDatabaseVersionIsToOutdated();
            });

            BindingContext = viewModel = new ItemsViewModel();
            bool answer = true;

            Device.BeginInvokeOnMainThread(async () =>
            {
                update = await database.CheckDatabaseVersionIsToOutdated();
                if (update == 1)
                {
                    answer = await Application.Current.MainPage.DisplayAlert("Aktualizacja bazy danych", "Czy chcesz zaktualizować bazę danych?", "Tak", "Nie");
                    if (answer == true)
                    {
                        WhereToThrowButton.IsEnabled = false;
                        DumpsterDescriptionButton.IsEnabled = false;
                        TestsButton.IsEnabled = false;
                        bool answerx = false;
                        var b = await database.UpdateAsync();
                        while (b == false || answerx == true)
                        {
                            answerx = await Application.Current.MainPage.DisplayAlert("Aktualizacja bazy", "Nie udało się zaktualizować bazy. Czy chcesz spróbować ponownie?", "Tak", "Nie");
                            b = await database.UpdateAsync();
                        }
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await Application.Current.MainPage.DisplayAlert("Aktualizacja bazy", "Baza danych została zaktualizowana z powodzeniem", "Ok");
                        });
                    }
                }
                if(update == -1)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert("Aktualizacja bazy", "Nie udało się sprawdzić czy baza danych jest aktualna. Sprawdź połaczenie internetowe.", "Ok");
                    });
                }

                WhereToThrowButton.IsEnabled = true;
                DumpsterDescriptionButton.IsEnabled = true;
                TestsButton.IsEnabled = true;

            });
        }



        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void onTestClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TestMainView());
        }

        private void onWhereToThrowAwayClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WhereToThrowSearch());
        }

        private void onDumpsterDescriptionClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DumpsterListViewPage());
        }
    }
}