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
    public partial class WhereToThrowResult : ContentPage
    {
        DumpsterDatabaseController dbDumpster;
        List<string> Dumpsters;
        List<Dumpster> DBDumpsters;
        Garbage SearchedGarbage;
        Dumpster SearchedDumpster;

        public WhereToThrowResult(Garbage searchedGarbage)
        {

            SetIcons();
            dbDumpster = new DumpsterDatabaseController();
            DBDumpsters = dbDumpster.GetDumpsters();
            SearchedGarbage = searchedGarbage;
            SearchedDumpster = dbDumpster.GetDumpster(searchedGarbage.DumpsterId);

            InitializeComponent();

            DumpsterImage.Source = Dumpsters[SearchedGarbage.DumpsterId - 1];
            DumpsterLabel.Text = DBDumpsters[SearchedGarbage.DumpsterId].Name;
            GarbageLabel.Text = SearchedGarbage.Name;
        }

        private void SetIcons()
        {
            Dumpsters = new List<string>();
            Dumpsters.Add("blackcontainerr.png");
            Dumpsters.Add("yellowcontainerr.png");
            Dumpsters.Add("pszok.png");
            Dumpsters.Add("icons8multipledevices96.png");
            Dumpsters.Add("whitecontainerr.png");
            Dumpsters.Add("icons8brickwall96.png");
            Dumpsters.Add("greencontainerr.png");
            Dumpsters.Add("icons8trash96.png");
            Dumpsters.Add("icons8clinic96.png");
            Dumpsters.Add("icons8poison96.png");
            Dumpsters.Add("bluecontainerr.png");
            Dumpsters.Add("icons8sofa96.png");
            Dumpsters.Add("icons8brownbagleaf100.png");
            Dumpsters.Add("icons8chargingbattery96.png");
            Dumpsters.Add("icons8christmasgift96.png");
            Dumpsters.Add("icons8hangar80.png");
            Dumpsters.Add("icons8fluorescentbulb96.png");
            Dumpsters.Add("icons8trolley96.png");

        }
    }
}