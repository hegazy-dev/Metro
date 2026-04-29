using Metro.Core.Entities;
using Metro.Core.Models.Graph;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Core.Interfaces
{
    public interface IStationRepository
    {
        Task<Station?> GetByIdAsync(int id);
        Task<List<Station>> GetAllAsync();
        Task<List<Station>> GetByLineIdAsync(int lineId);
        Task<List<StationGraphNode>> GetAllStationsAsync();
    }
}
