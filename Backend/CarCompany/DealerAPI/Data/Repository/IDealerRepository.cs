using DealerAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerAPI.Data.Repository
{
    public interface IDealerRepository
    {
        Task<DealerEntity> GetDealerAsync(int id, bool showCars = false);
        Task<IEnumerable<DealerEntity>> GetDealersAsync(string orderBy, bool showCars = false);
        void CreateDealer(DealerEntity newDealer);
        bool UpdateDealer(DealerEntity dealer);
        Task<bool> DeleteDealer(int id);

        Task<CarEntity> GetCarAsync(int id);
        Task<IEnumerable<CarEntity>> GetCarsAsync(int dealerId);
        void CreateCar(CarEntity newCar);
        bool UpdateCar(CarEntity Car);
        Task<bool> DeleteCarAsync(int id);


        Task<bool> SaveChangesAsync();
    }
}
