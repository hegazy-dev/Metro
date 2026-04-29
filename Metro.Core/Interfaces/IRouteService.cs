namespace Metro.Core.Interfaces;

public interface IRouteService
{
    Task<List<int>> GetShortestPathAsync(int startId, int endId);
}