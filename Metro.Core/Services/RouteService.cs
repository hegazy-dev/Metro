using Metro.Core.Exceptions;
using Metro.Core.Interfaces;

namespace Metro.Data.Services;

public class RouteService : IRouteService
{
    private readonly IGraphBuilder _graphBuilder;

    public RouteService(IGraphBuilder graphBuilder)
    {
        _graphBuilder = graphBuilder;
    }

    public async Task<List<int>> GetShortestPathAsync(int startId, int endId)
    {
        var graph = await _graphBuilder.BuildGraphAsync();

        if (!graph.ContainsKey(startId))
            throw new StationNotFoundException($"Station with id {startId} was not found.");

        if (!graph.ContainsKey(endId))
            throw new StationNotFoundException($"Station with id {endId} was not found.");

        if (startId == endId)
            return new List<int> { startId };

        var distances = graph.Keys.ToDictionary(id => id, _ => int.MaxValue);
        var previous = graph.Keys.ToDictionary(id => id, _ => (int?)null);
        var priorityQueue = new PriorityQueue<int, int>();

        distances[startId] = 0;
        priorityQueue.Enqueue(startId, 0);

        while (priorityQueue.Count > 0)
        {
            priorityQueue.TryDequeue(out var currentStationId, out var currentDistance);

            if (currentDistance > distances[currentStationId])
                continue;

            if (currentStationId == endId)
                break;

            foreach (var neighbor in graph[currentStationId])
            {
                var newDistance = distances[currentStationId] + neighbor.Weight;

                if (newDistance < distances[neighbor.StationId])
                {
                    distances[neighbor.StationId] = newDistance;
                    previous[neighbor.StationId] = currentStationId;
                    priorityQueue.Enqueue(neighbor.StationId, newDistance);
                }
            }
        }

        if (distances[endId] == int.MaxValue)
            throw new InvalidRouteException(
                $"No route found between station {startId} and station {endId}.");

        return ReconstructPath(previous, endId);
    }

    private static List<int> ReconstructPath(Dictionary<int, int?> previous, int endId)
    {
        var path = new List<int>();
        int? current = endId;

        while (current != null) 
        {
            path.Add(current.Value);
            current = previous[current.Value];
        }

        path.Reverse();
        return path;
    }
}