using System;
using System.Collections.Generic;
using System.Text;

namespace Metro.Data.Seed.SeedModels
{
    public class PricingRuleSeedModel
    {
        public int Id { get; set; }
        public int MinStations { get; set; }
        public int MaxStations { get; set; }
        public decimal Price { get; set; }
    }
}
