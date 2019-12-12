using EcoHelper.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views
{
    [DesignTimeVisible(true)]
    public partial class CalculateResourcesView : ContentPage
    {
        enum Unit { KWh, GJ };
        Unit IdUnit;

        List<ResourceItem> resourceItems;
        public CalculateResourcesView()
        {
            InitializeComponent();

            resourceItems = new List<ResourceItem>
            {
                new ResourceItem {ResourceType=ResourceType.Gas, Title="Gaz ziemny [m3]", IconName="icons8gas96", UnitValue=9.7222223032, ResourceUnitText="[m3]"},
                new ResourceItem {ResourceType=ResourceType.Coal, Title="Węgiel [kg]", IconName="icons8coal96", UnitValue=7.4444444560, ResourceUnitText="[kg]" },
                new ResourceItem {ResourceType=ResourceType.Straw, Title="Słoma (15% wilgotności) [kg]", IconName="icons8wheat96", UnitValue=3.97222064039, ResourceUnitText="[kg]" },
                new ResourceItem {ResourceType=ResourceType.Wood, Title="Drewno (15% wilgotności) [kg]", IconName="icons8forest96", UnitValue=4.89444445314, ResourceUnitText="[kg]" },
                new ResourceItem {ResourceType=ResourceType.HeatingOil, Title="Olej opałowy [l]", IconName="icons8oilindustry96", UnitValue=9.88888884, ResourceUnitText="[l]" }

            };

            KwhSwitch.IsToggled = true;
            IdUnit = Unit.KWh;
            ListViewMenu.ItemsSource = resourceItems;


            ListViewMenu.ItemSelected += (sender, e) =>
            {
                
                if (e.SelectedItem == null)
                    return;

                var id = (int)((ResourceItem)e.SelectedItem).ResourceType;
                CalculateResources(id);
            };
        }

        

        private void KwhSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            IdUnit = Unit.KWh;
            GjSwitch.IsToggled = false;
        }

        private void GjSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            IdUnit = Unit.GJ;
            KwhSwitch.IsToggled = false;
        }

        private void CalculateResources(int id)
        {
            double result;
            result = CalculateResult(resourceItems[id].UnitValue);
            ResultText.Text = result < 0 ? String.Format("%.2f", result) + " " + resourceItems[id].ResourceUnitText : ResultText.Text = "Wybierz jednostkę";
            ResultText.Text = result.ToString() + " " + resourceItems[id].ResourceUnitText;
        }

        private double CalculateResult(double x)
        {
            double Energy;
            Double.TryParse(EnergyText.Text,out Energy);
            switch (IdUnit)
            {
                case Unit.KWh:
                    return Energy / x;
                case Unit.GJ:
                    return Energy * 277.78 / x;
            }
            return -1;
        }
    }
}