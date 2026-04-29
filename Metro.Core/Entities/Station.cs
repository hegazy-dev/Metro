using System;
using System.Collections.Generic;
using System.Text;

namespace Metro.Core.Entities
{
    public class Station
    {

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int LineId { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public int Order { get; private set; }

        public Line Line { get; private set; }

        public ICollection<StationConnection> FromConnections { get; private set; } = new List<StationConnection>();
        public ICollection<StationConnection> ToConnections { get; private set; } = new List<StationConnection>();

        private Station() { }

        public Station(int id, string name, int lineId, double latitude, double longitude, int order)
        {
            Id = id;
            Name = name;
            LineId = lineId;
            Latitude = latitude;
            Longitude = longitude;
            Order = order;
        }

    }
}
