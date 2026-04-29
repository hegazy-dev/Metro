using Metro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metro.Core.Interfaces
{
    public interface ILineRepository
    {
            Task<Line?> GetByIdAsync(int id);
            Task<List<Line>> GetAllAsync();
    }
}
