using DealerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerAPI.Services
{
    public interface ICarService
    {
        Task<CarModel> GetCarAsync(int DealerId, int id);
        Task<IEnumerable<CarModel>> GetCarsAsync(int DealerId);
        Task<CarModel> CreateCarAsync(int DealerId, CarModel newCar);
        Task<bool> UpdateCarAsync(int DealerId, int id, CarModel Car);
        Task<bool> DeleteCarAsync(int DealerId, int id);
    }
}
