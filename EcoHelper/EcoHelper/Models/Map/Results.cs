using System;
using System.Collections.Generic;
using System.Text;

namespace EcoHelper.Models.Map
{
    public class Results
    {
        public string Formatted_Address { get; set; }
        public string Place_Id { get; set; }
        public string Name { get; set; }
        public Geometry Geometry { get; set; }
    }
}
