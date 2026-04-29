using Metro.Core.Entities;
using Metro.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metro.Data.Repositories
{
    public class PricingRuleRepository : IPricingRuleRepository
    {
        private readonly MetroDbContext _context;

        public PricingRuleRepository(MetroDbContext context)
        {
            _context = context;
        }

        public async Task<List<PricingRule>> GetAllAsync()
        {
            return await _context.PricingRules
                .OrderBy(r => r.MinStations)
                .ToListAsync();
        }
    }
}
