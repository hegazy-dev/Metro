using Metro.Core.Entities;

namespace Metro.Core.Interfaces;

public interface IPricingService
{
    decimal CalculatePrice(int stationCount, IEnumerable<PricingRule> pricingRules);
}
