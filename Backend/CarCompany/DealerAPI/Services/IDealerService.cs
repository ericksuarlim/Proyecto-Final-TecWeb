using DealerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerAPI.Services
{
    public interface IDealerService
    {
        Task<DealerModel> GetDealerAsync(int id);
        Task<IEnumerable<DealerModel>> GetDealersAsync(string orderBy = "id", bool showCars = false);
        Task <DealerModel> CreateDealerAsync(DealerModel newDealer);
        Task<bool> UpdateDealerAsync(int id, DealerModel dealer);
        Task<bool> DeleteDealerAsync(int id);
    }
}
