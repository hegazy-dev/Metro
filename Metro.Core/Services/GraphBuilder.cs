using Metro.Core.Interfaces;
using Metro.Core.Models.Graph;
using Microsoft.Extensions.Caching.Memory;

namespace Metro.Data.Services;

public class GraphBuilder : IGraphBuilder
{
    private const string CacheKey = "metro_graph";

    private readonly IStationRepository _stationRepository;
    private readonly IStationConnectionRepository _stationConnectionRepository;
    private readonly IMemoryCache _memoryCache;

    public GraphBuilder(
        IStationRepository stationRepository,
        IStationConnectionRepository stationConnectionRepository,
        IMemoryCache memoryCache)
    {
        _stationRepository = stationRepository;
        _stationConnectionRepository = stationConnectionRepository;
        _memoryCache = memoryCache;
    }

    public async Task<Dictionary<int, List<Neighbor>>> BuildGraphAsync()
    {
        if (_memoryCache.TryGetValue(CacheKey, out Dictionary<int, List<Neighbor>>? cachedGraph)
            && cachedGraph is not null)
        {
            return cachedGraph;
        }

        var stations = await _stationRepository.GetAllStationsAsync();
        var connections = await _stationConnectionRepository.GetAllConnectionsAsync();

        var graph = new Dictionary<int, List<Neighbor>>();
        var edgeSet = new HashSet<string>();

        // ensure every station exists as a key
        foreach (var station in stations)
        {
            graph[station.Id] = new List<Neighbor>();
        }

        foreach (var connection in connections)
        {
            AddEdge(graph, edgeSet, connection.FromStationId, connection.ToStationId);
            AddEdge(graph, edgeSet, connection.ToStationId, connection.FromStationId);
        }

        _memoryCache.Set(CacheKey, graph, TimeSpan.FromMinutes(30));

        return graph;
    }

    private static void AddEdge(
        Dictionary<int, List<Neighbor>> graph,
        HashSet<string> edgeSet,
        int fromStationId,
        int toStationId)
    {
        if (!graph.ContainsKey(fromStationId))
        {
            graph[fromStationId] = new List<Neighbor>();
        }

        if (!graph.ContainsKey(toStationId))
        {
            graph[toStationId] = new List<Neighbor>();
        }

        var edgeKey = $"{fromStationId}-{toStationId}";

        if (edgeSet.Contains(edgeKey))
        {
            return;
        }

        graph[fromStationId].Add(new Neighbor
        {
            StationId = toStationId,
            Weight = 1
        });

        edgeSet.Add(edgeKey);
    }
}