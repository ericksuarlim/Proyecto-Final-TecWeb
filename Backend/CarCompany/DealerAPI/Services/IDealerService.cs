using DealerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerAPI.Services
{
    public interface IDealerService
    {
        DealerModel GetDealer(int id);
        IEnumerable<DealerModel> GetDealers(string orderBy = "id");
        DealerModel CreateDealer(DealerModel newDealer);
        bool UpdateDealer(int id, DealerModel dealer);
        bool DeleteDealer(int id);
    }
}
