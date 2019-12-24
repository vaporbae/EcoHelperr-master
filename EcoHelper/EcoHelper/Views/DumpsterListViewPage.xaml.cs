using EcoHelper.Models;
using EcoHelper.Views.DumpsterDetails;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class DumpsterListViewPage: ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        Dictionary<int, NavigationPage> DumpsterPages = new Dictionary<int, NavigationPage>();

        DumpsterListViewPage MainPage { get => Application.Current.MainPage as DumpsterListViewPage; }
        List<DumpsterListItem> menuItems;
        private INavigation _navigation;

        public DumpsterListViewPage()
        {
            InitializeComponent();

            this._navigation = Navigation;

            menuItems = new List<DumpsterListItem>
            {
                new DumpsterListItem {Id = DumpsterItemType.GreenDumpsterPage, Title="Zielony kontener", Color="#6BB34F", IconName="icons8brokenbottle96.png" },
                new DumpsterListItem {Id = DumpsterItemType.Yellow, Title="Żółty kontener", Color="#FFD185", IconName="icons8plastic96.png"},
                new DumpsterListItem {Id = DumpsterItemType.Blue, Title="Niebieski kontener", Color="#00A6FF", IconName="icons8pape96.png"},
                new DumpsterListItem {Id = DumpsterItemType.Brown, Title="Brązowy kontener", Color="#B8977E", IconName="icons8ingredients96.png" },
                new DumpsterListItem {Id = DumpsterItemType.MixedWaste, Title="Odpady zmieszane", Color="#5A6978", IconName="icons8trash96.png"},
                new DumpsterListItem {Id = DumpsterItemType.GreenWaste, Title="Odpady zielone", Color="#886D59", IconName="icons8leaf96.png"},
                new DumpsterListItem {Id = DumpsterItemType.ElectronicWaste, Title="Elektroodpady", Color="#886D59", IconName="icons8multipledevices96.png"},
                new DumpsterListItem {Id = DumpsterItemType.MedicinesAndThermometrWaste, Title="Leki i termometry", Color="#343F4B", IconName="icons8pills96.png" },
                new DumpsterListItem {Id = DumpsterItemType.ConstructionWaste, Title="Odpady budowlane", Color="#FFBA5C", IconName="icons8brickwall96.png" },
                new DumpsterListItem {Id = DumpsterItemType.TireWaste, Title="Opony", Color="#FFBA5C", IconName="icons8wheel96.png" },
                new DumpsterListItem {Id = DumpsterItemType.BatteriesWaste, Title="Baterie i akumulatory", Color="#976DD0", IconName="icons8chargingbattery96.png" },
                new DumpsterListItem {Id = DumpsterItemType.DangerousWaste, Title="Odpady niebezpieczne", Color="#FF9052", IconName="icons8error96.png" },
                new DumpsterListItem {Id = DumpsterItemType.Grey, Title="Szary worek", Color="#5A6978", IconName="icons8compostheapfilled100.png" },
                new DumpsterListItem {Id = DumpsterItemType.ComposterWaste, Title="Kompostownik", Color="#886D59", IconName="icons8compostheap96.png" },
                new DumpsterListItem {Id = DumpsterItemType.AuthorisedEntity, Title="Uprawniony podmiot", Color="#F95F62" , IconName="icons8highpriority96.png"}
            };

            ListViewDumpsterMenu.ItemsSource = menuItems;

            ListViewDumpsterMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((DumpsterListItem)e.SelectedItem).Id;
                await NavigateFromMenu(id);
            };
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        public async Task NavigateFromMenu(int id)
        {
                switch (id)
                {
                    case (int)DumpsterItemType.GreenDumpsterPage:
                        await this._navigation.PushAsync(new GreenDumpsterPage(),true);
                        break;
                    case (int)DumpsterItemType.Yellow:
                        await this._navigation.PushAsync(new YellowDumpsterPage(), true);
                        break;
                    case (int)DumpsterItemType.Blue:
                        await this._navigation.PushAsync(new BlueDumpsterPage(), true);
                        break;
                    case (int)DumpsterItemType.Brown:
                        await this._navigation.PushAsync(new BrownDumpsterPage(), true);
                        break;
                    case (int)DumpsterItemType.MixedWaste:
                        await this._navigation.PushAsync(new MixedWasteDumpsterPage(), true);
                        break;
                    case (int)DumpsterItemType.GreenWaste:
                        await this._navigation.PushAsync(new GreenWastePage(), true);
                        break;
                    case (int)DumpsterItemType.MedicinesAndThermometrWaste:
                                await this._navigation.PushAsync(new PharmacyPage(), true);
                                break;
            }
        }
    }
}
