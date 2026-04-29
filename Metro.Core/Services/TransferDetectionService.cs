using Metro.Core.Entities;
using Metro.Core.Interfaces;

namespace Metro.Core.Services;

public class TransferDetectionService : ITransferDetectionService
{
    public int CountTransfers(IList<Station> stations)
    {
        if (stations is null)
            throw new ArgumentNullException(nameof(stations));

        if (stations.Count < 2)
            return 0;

        int transfers = 0;

        for (int i = 1; i < stations.Count; i++)
        {
            if (stations[i].LineId != stations[i - 1].LineId)
                transfers++;
        }

        return transfers;
    }
}
