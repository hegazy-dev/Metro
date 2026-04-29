using Metro.Core.Interfaces;

namespace Metro.Core.Services;

public class TravelTimeService : ITravelTimeService
{
    private const int MinutesPerStation = 2;

    public int CalculateTravelTime(int stationCount)
    {
        if (stationCount < 0)
            throw new ArgumentException("Station count cannot be negative.", nameof(stationCount));

        return stationCount * MinutesPerStation;
    }
}
