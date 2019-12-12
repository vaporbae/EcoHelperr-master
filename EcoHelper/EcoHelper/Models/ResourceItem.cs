using System;
using System.Collections.Generic;
using System.Text;

namespace EcoHelper.Models
{
    public enum ResourceType
    {
        Gas,
        Coal,
        Straw,
        Wood,
        HeatingOil
    }
    public class ResourceItem
    {
        public ResourceType ResourceType { get; set; }

        public string Title { get; set; }
        public string IconName { get; set; }
        public double UnitValue { get; set; }
        public string ResourceUnitText { get; set; }
    }
}
