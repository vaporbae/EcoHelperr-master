using System;
using System.Collections.Generic;
using System.Text;

namespace EcoHelper.Models
{
    public enum DumpsterItemType
    {
        GreenDumpsterPage,
        Yellow,
        Blue,
        Brown,
        MixedWaste,
        GreenWaste,
        ElectronicWaste,
        MedicinesAndThermometrWaste,
        ConstructionWaste,
        TireWaste,
        BatteriesWaste,
        DangerousWaste,
        Grey,
        ComposterWaste,
        AuthorisedEntity
    }
    public class DumpsterListItem
    {
        public DumpsterItemType Id { get; set; }

        public string Title { get; set; }
        public string Color { get; set; }
        public string IconName { get; set; }
    }
}
