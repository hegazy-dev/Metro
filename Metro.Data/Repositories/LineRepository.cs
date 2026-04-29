using Metro.Core.Entities;
using Metro.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metro.Data.Repositories
{
    public class LineRepository : ILineRepository
    {
        private readonly MetroDbContext _context;

        public LineRepository(MetroDbContext context)
        {
            _context = context;
        }

        public async Task<Line?> GetByIdAsync(int id)
        {
            return await _context.Lines
                .Include(l => l.Stations)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Line>> GetAllAsync()
        {
            return await _context.Lines
                .ToListAsync();
        }
    }
}
