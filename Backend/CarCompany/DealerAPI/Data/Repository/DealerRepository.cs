using DealerAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerAPI.Data.Repository
{
    public class DealerRepository : IDealerRepository
    {
        private List<DealerEntity> dealers = new List<DealerEntity>();
        private List<CarEntity> cars = new List<CarEntity>();

        public DealerRepository()
        {
            dealers.Add(new DealerEntity()
            {
                Id = 1,
                Name = "Toyosa",
                Address = "AV. America y Tarija",
                Fundation = new DateTime(1992, 4, 20),
                Phone = 4243456
            });

            dealers.Add(new DealerEntity()
            {
                Id = 2,
                Name = "Imcruz",
                Address = "Av America 1638",
                Fundation = new DateTime(2003, 9, 11),
                Phone = 4410464
            });

            cars.Add(new CarEntity()
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Camry",
                Price = 23000,
                DealerId = 1

            });
            cars.Add(new CarEntity()
            {
                Id = 2,
                Brand = "Suzuki",
                Model = "Vitara",
                Price = 27000,
                DealerId = 1

            });

            cars.Add(new CarEntity()
            {
                Id = 3,
                Brand = "Subaru",
                Model = "Legacy",
                Price = 18000,
                DealerId = 2

            });

            cars.Add(new CarEntity()
            {
                Id = 4,
                Brand = "Jeep",
                Model = "Cherokee",
                Price = 25000,
                DealerId = 2

            });
        }

        public CarEntity CreateCar(CarEntity newCar)
        {
            var newId = cars.OrderByDescending(d => d.Id).FirstOrDefault().Id + 1;
            newCar.Id = newId;
            cars.Add(newCar);
            return newCar;
        }

        public DealerEntity CreateDealer(DealerEntity newDealer)
        {
            var newId = dealers.OrderByDescending(r => r.Id).First().Id + 1;
            newDealer.Id = newId;
            dealers.Add(newDealer);
            return newDealer;
        }

        public bool DeleteCar(int id)
        {
            var dish = GetCar(id);
            return cars.Remove(dish);
        }

        public bool DeleteDealer(int id)
        {
            var dealerDelete = GetDealer(id);
            dealers.Remove(dealerDelete);
            return true;
        }

        public CarEntity GetCar(int id)
        {
            return cars.SingleOrDefault(d => d.Id == id);
        }

        public IEnumerable<CarEntity> GetCars(int dealerId)
        {
            return cars.Where(d => d.DealerId == dealerId);
        }

        public DealerEntity GetDealer(int id, bool showCars = false)
        {
            return dealers.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<DealerEntity> GetDealers(string orderBy, bool showCars = false)
        {
            switch (orderBy)
            {
                case "id":
                    return dealers.OrderBy(r => r.Id);
                case "name":
                    return dealers.OrderBy(r => r.Name);
                case "address":
                    return dealers.OrderBy(r => r.Address);
                default:
                    return dealers;
            }
        }

        public bool UpdateCar(CarEntity car)
        {
            var cr = GetCar(car.Id);
            cr.Brand = car.Brand;
            cr.Model = car.Model;
            cr.Price = car.Price;
            cr.Year = car.Year;
            return true;

        }
        public bool UpdateDealer(DealerEntity dealer)
        {
            var dlr = GetDealer(dealer.Id);
            dlr.Name = dealer.Name ?? dlr.Name;
            dlr.Phone = dealer.Phone ?? dlr.Phone;
            dlr.Address = dealer.Address ?? dlr.Address;
            dlr.Fundation = dealer.Fundation ?? dlr.Fundation;
            return true;
        }
    }
}
