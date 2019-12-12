using System;
using System.Collections.Generic;
using System.Text;

namespace EcoHelper.Models.Map
{
    public class Results
    {
        public string FormattedAddress { get; set; }
        public int PlaceId { get; set; }
        public Geometry Geometry { get; set; }
    }
}
