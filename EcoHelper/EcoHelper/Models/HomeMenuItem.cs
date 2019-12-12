using System;
using System.Collections.Generic;
using System.Text;

namespace EcoHelper.Models
{
    public enum MenuItemType
    {
        Browse,
        CalculateResources
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
        public string IconName { get; set; }
    }
}
