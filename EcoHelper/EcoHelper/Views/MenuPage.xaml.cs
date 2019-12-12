using EcoHelper.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.CalculateResources, Title="Dlaczego nie palimy śmieci", IconName="icons8matches96" },
                new HomeMenuItem {Id = MenuItemType.CalculateResources, Title="Przelicznik energii na surowce", IconName="icons8solarenergy96" },
                new HomeMenuItem {Id = MenuItemType.CalculateResources, Title="Ciekawostki", IconName="icons8hint96" },
                new HomeMenuItem {Id = MenuItemType.CalculateResources, Title="Sprawdź swoją wiedzę", IconName="icons8passfail96" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}