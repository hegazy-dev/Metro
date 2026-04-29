using System.Text.Json.Serialization;

namespace Metro.Core.Entities;

public class StationConnection
{
    public int Id { get; private set; }

    [JsonPropertyName("fromStationId")]
    public int FromStationId { get; private set; }

    public int ToStationId { get; private set; }

    public Station? FromStation { get; private set; }
    public Station? ToStation { get; private set; }

    private StationConnection() { }

    public StationConnection(int fromStationId, int toStationId)
    {
        FromStationId = fromStationId;
        ToStationId = toStationId;
    }

    public StationConnection(int id, int fromStationId, int toStationId)
    {
        Id = id;
        FromStationId = fromStationId;
        ToStationId = toStationId;
    }
}