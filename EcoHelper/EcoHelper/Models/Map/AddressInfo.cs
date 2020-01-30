using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoHelper.Models.Map
{
    public class AddressInfo
    {
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PlaceId { get; set; }
        public string Name { get; set; }

        public AddressInfo() { }
        public AddressInfo(string address, double latitude, double longitude, string placeId, string name)
        {
            this.Address = address;
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.PlaceId = placeId;
            this.Name = name;
        }
    }
}
