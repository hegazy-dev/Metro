using Metro.Core.Entities;
using Metro.Core.Models.Graph;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metro.Core.Interfaces
{
    public interface IStationConnectionRepository
    {
        //Task<List<StationConnection>> GetAllAsync();
        Task<IEnumerable<StationConnection>> GetConnectionsByStationIdAsync(int stationId);

        Task<List<StationConnectionGraphEdge>> GetAllConnectionsAsync();
    }
}
