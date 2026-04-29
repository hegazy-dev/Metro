using Metro.Core.Entities;
using Metro.Core.Interfaces;

namespace Metro.Core.Services;

public class PricingService : IPricingService
{
    public decimal CalculatePrice(int stationCount, IEnumerable<PricingRule> pricingRules)
    {
        if (stationCount <= 0)
            throw new ArgumentException("Station count must be greater than zero.", nameof(stationCount));

        if (pricingRules is null || !pricingRules.Any())
            throw new ArgumentException("Pricing rules cannot be empty.", nameof(pricingRules));

        var matchedRule = pricingRules.FirstOrDefault(rule => rule.IsMatch(stationCount));

        if (matchedRule is null)
            throw new InvalidOperationException($"No pricing rule found for station count: {stationCount}");

        return matchedRule.Price;
    }
}
