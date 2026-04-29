using Metro.Core.DTOs;

namespace Metro.Core.Interfaces;

public interface IMetroService
{
    Task<RouteResultDto> GetRouteAsync(int startId, int endId);
}
