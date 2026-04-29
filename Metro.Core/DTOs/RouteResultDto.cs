namespace Metro.Core.DTOs;

public class RouteResultDto
{
    public List<string> Stations { get; set; } = new();

    public string FromStationName { get; set; }

    public string ToStationName { get; set; }

    public int StationCount { get; set; }

    public int Transfers { get; set; }

    public decimal Price { get; set; }

    public int EstimatedTimeMinutes { get; set; }
}