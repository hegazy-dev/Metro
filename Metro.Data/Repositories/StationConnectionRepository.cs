using Metro.Core.Entities;
using Metro.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Metro.Core.Models.Graph;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metro.Data.Repositories
{
    public class StationConnectionRepository : IStationConnectionRepository
    {
        private readonly MetroDbContext _context;

        public StationConnectionRepository(MetroDbContext context)
        {
            _context = context;
        }

        //public async Task<List<StationConnection>> GetAllAsync()
        //{
        //    return await _context.StationConnections
        //        .ToListAsync();
        //}

        public async Task<IEnumerable<StationConnection>> GetConnectionsByStationIdAsync(int stationId)
        {
            return await _context.StationConnections
                .Where(sc => sc.FromStationId == stationId || sc.ToStationId == stationId)
                .ToListAsync();
        }

        public async Task<List<StationConnectionGraphEdge>> GetAllConnectionsAsync()
        {
            return await _context.StationConnections
                .AsNoTracking()
                .Select(c => new StationConnectionGraphEdge
                {
                    FromStationId = c.FromStationId,
                    ToStationId = c.ToStationId
                })
                .ToListAsync();
        }
    }
}
