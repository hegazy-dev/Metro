using System;
using System.Collections.Generic;
using System.Text;

namespace Metro.Data.Seed.SeedModels
{
    public class StationSeedModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LineId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Order { get; set; }
    }
}
