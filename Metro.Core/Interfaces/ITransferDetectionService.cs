using Metro.Core.Entities;

namespace Metro.Core.Interfaces;

public interface ITransferDetectionService
{
    int CountTransfers(IList<Station> stations);
}
