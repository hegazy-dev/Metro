using Metro.Core.Models.Graph;

namespace Metro.Core.Interfaces;

public interface IGraphBuilder
{
    Task<Dictionary<int, List<Neighbor>>> BuildGraphAsync();
}