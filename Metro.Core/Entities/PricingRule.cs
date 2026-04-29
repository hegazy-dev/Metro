namespace Metro.Core.Entities;

public class PricingRule
{
    public int Id { get; private set; }

    public int MinStations { get; private set; }

    public int MaxStations { get; private set; }

    public decimal Price { get; private set; }

    private PricingRule() { }

    public PricingRule(int id, int minStations, int maxStations, decimal price)
    {
        Id = id;
        MinStations = minStations;
        MaxStations = maxStations;
        Price = price;
    }

    public bool IsMatch(int stationCount)
    {
        return stationCount >= MinStations
            && stationCount <= MaxStations;
    }
}