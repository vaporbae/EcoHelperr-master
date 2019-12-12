using EcoHelper.Data;
using EcoHelper.Models;
using EcoHelper.Models.Deserialize;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcoHelper.Services
{
    public class UpdateDatabase
    {
        public const string BasicURL = "http://eco-helper.azurewebsites.net";
        DumpsterDatabaseController dbDumpster;
        GarbageDatabaseController dbGarbage;
        WebInterface webInterface;
        public UpdateDatabase() { }
        public Task<bool> UpdateAsync()
        {
            dbDumpster = new DumpsterDatabaseController();
            dbGarbage = new GarbageDatabaseController();
            webInterface = new WebInterface(new System.Net.Http.HttpClient());

            var dumpsterReqString = webInterface.MakeGetRequest(BasicURL + "/dumpsters").ToString();
            var garbageReqString = webInterface.MakeGetRequest(BasicURL + "/garbages").ToString();

            var dumpsters = JsonConvert.DeserializeObject<DumpstersList>(dumpsterReqString);
            var garbages = JsonConvert.DeserializeObject<GarbageList>(garbageReqString);

            foreach(Dumpster dumpster in dumpsters.Dumpsters)
            {
                dbDumpster.CreateDumpster(dumpster.Name);
            }

            foreach(Garbage garbage in garbages.Garbages)
            {
                var g = dbGarbage.CreateGarbage(garbage.Name, garbage.DumpsterId);
                dbDumpster.AddGarbage(g,g.DumpsterId);
            }


            //RootObject m = JsonConvert.DeserializeObject<RootObject>(yourstring);

            //zrobic request
            //z jsona bezposrednio na grupe ta dac tabele
            //pobrac grupe dumpsterow
            //pobrac grupe garbage
            //w kazdym garbage dodac do dumpstera o odpowiednim id
            return true;
        }
    }
}
