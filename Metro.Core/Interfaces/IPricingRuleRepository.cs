using Metro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metro.Core.Interfaces
{
    public interface IPricingRuleRepository
    {
        Task<List<PricingRule>> GetAllAsync();
    }
}
