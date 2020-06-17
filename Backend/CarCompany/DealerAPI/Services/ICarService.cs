using DealerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerAPI.Services
{
    public interface ICarService
    {
        CarModel GetCar(int DealerId, int id);
        IEnumerable<CarModel> GetCars(int DealerId);
        CarModel CreateCar(int DealerId, CarModel newCar);
        bool UpdateCar(int DealerId, int id, CarModel Car);
        bool DeleteCar(int DealerId, int id);
    }
}
