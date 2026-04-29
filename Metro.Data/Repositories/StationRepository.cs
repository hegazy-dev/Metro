using Metro.Core.Entities;
using Metro.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Metro.Core.Models.Graph;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metro.Data.Repositories
{
    public  class StationRepository : IStationRepository
    {
        private readonly MetroDbContext _context;

        public StationRepository(MetroDbContext context)
        {
            _context = context;
        }

        public async Task<Station?> GetByIdAsync(int id)
        {
            return await _context.Stations
                .Include(s => s.Line)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Station>> GetAllAsync()
        {
            return await _context.Stations
                .Include(s => s.Line)
                .ToListAsync();
        }

        public async Task<List<Station>> GetByLineIdAsync(int lineId)
        {
            return await _context.Stations
                .Where(s => s.LineId == lineId)
                .OrderBy(s => s.Order)
                .ToListAsync();
        }

        public async Task<List<StationGraphNode>> GetAllStationsAsync()
        {
            return await _context.Stations
                .AsNoTracking()
                .Select(s => new StationGraphNode
                {
                    Id = s.Id,
                    Name = s.Name,
                    LineId = s.LineId
                })
                .ToListAsync();
        }
    }
}
