using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using EcoHelper.Models;
using EcoHelper.Views.DoNotBurnWaste;
using EcoHelper.Views.WhySegregate;
using EcoHelper.Views.InterestingFacts;
using EcoHelper.Views.Tips;

namespace EcoHelper.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.MainMenu:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.CalculateResources:
                        MenuPages.Add(id, new NavigationPage(new CalculateResourcesView()));
                        break;
                    case (int)MenuItemType.DoNotBurnWaste:
                        MenuPages.Add(id, new NavigationPage(new DoNotBurnWasteView()));
                        break;
                    case (int)MenuItemType.WhySegregate:
                        MenuPages.Add(id, new NavigationPage(new WhySegregateView()));
                        break;
                    case (int)MenuItemType.InterestingFacts:
                        MenuPages.Add(id, new NavigationPage(new InterestingFactsView()));
                        break;
                    case (int)MenuItemType.Tips:
                        MenuPages.Add(id, new NavigationPage(new TipsView()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}