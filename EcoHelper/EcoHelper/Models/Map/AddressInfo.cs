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
        public int PlaceId { get; set; }

        public AddressInfo() { }
        public AddressInfo(string address, double latitude, double longitude, int placeId)
        {
            this.Address = address;
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.PlaceId = placeId;
        }
    }
}
