using System.Text.Json.Serialization;

namespace Metro.Data.Seed.SeedModels
{
    public class ConnectionSeedModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("fromStationId")]
        public int FromStationId { get; set; }

        [JsonPropertyName("toStationId")]
        public int ToStationId { get; set; }
    }
}
