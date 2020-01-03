using EcoHelper.Data;
using EcoHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views.WhereToThrow
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WhereToThrowSearch : ContentPage
    {
        Garbage SelectedGarbage;
        GarbageDatabaseController dbGarbage;
        List<Garbage> Garbages;
        List<Garbage> SearchedGarbages;
        DumpsterDatabaseController dbDumpster;
        List<Dumpster> Dumpsters;


        public WhereToThrowSearch()
        {
            InitializeComponent();

            AbsoluteLayout.IsVisible = false;

            dbGarbage = new GarbageDatabaseController();
            dbDumpster = new DumpsterDatabaseController();
            Garbages = dbGarbage.GetGarbages();
            Dumpsters = dbDumpster.GetDumpsters();
            SetIcons();

            GarbagesList.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                SelectedGarbage = ((Garbage)e.SelectedItem);
                GarbageText.Text = SelectedGarbage.Name;
                AbsoluteLayout.IsVisible = false;
            };
        }

        private void OnSearch(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WhereToThrowResult(SelectedGarbage));
        }

        private void OnSuggestClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProposeWhereToThrowView());
        }

        private void OnTextChanged(object sender, EventArgs eventArgs)
        {
            AbsoluteLayout.IsVisible = true;
            if (!string.IsNullOrWhiteSpace(GarbageText.Text) && GarbageText.Text.Length > 2)
            {
                SearchedGarbages = Garbages.Where(x => x.Name.ToLower().Contains(GarbageText.Text.ToLower())).ToList();
                foreach(Garbage g in SearchedGarbages)
                {
                    g.IconName = Dumpsters[g.DumpsterId-1].IconName;
                }
                GarbagesList.ItemsSource = null;
                GarbagesList.ItemsSource = SearchedGarbages;
            }
            else
            {
                GarbagesList.ItemsSource = null;
            }
        }

        private void SetIcons()
        {
            Dumpsters[0].IconName = "icons8trash96.png";
            Dumpsters[1].IconName = "icons8plastic96.png";
            Dumpsters[2].IconName = "icons8error96.png";
            Dumpsters[3].IconName = "icons8multipledevices96.png";
            Dumpsters[4].IconName = "icons8fragile.png";
            Dumpsters[5].IconName = "icons8brickwall96.png";
            Dumpsters[6].IconName = "icons8brokenbottle96.png";
            Dumpsters[7].IconName = "icons8trash96.png";
            Dumpsters[8].IconName = "icons8pills96.png";
            Dumpsters[9].IconName = "icons8poison96.png";
            Dumpsters[10].IconName = "icons8pape96.png";
            Dumpsters[11].IconName = "icons8sofa96.png";
            Dumpsters[12].IconName = "icons8brownbagleaf100.png";
            Dumpsters[13].IconName = "icons8chargingbattery96.png";
            Dumpsters[14].IconName = "icons8christmasgift96.png";
            Dumpsters[15].IconName = "icons8hangar80.png";
            Dumpsters[16].IconName = "icons8fluorescentbulb96.png";
            Dumpsters[17].IconName = "icons8trolley96.png";

        }
    }
}