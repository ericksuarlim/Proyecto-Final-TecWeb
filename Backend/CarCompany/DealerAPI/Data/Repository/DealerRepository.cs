using DealerAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerAPI.Data.Repository
{
    public class DealerRepository : IDealerRepository
    {
        private DealerDbContext dbContext;
        public DealerRepository(DealerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

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
                //DealerId = 1

            });
            cars.Add(new CarEntity()
            {
                Id = 2,
                Brand = "Suzuki",
                Model = "Vitara",
                Price = 27000,
                //DealerId = 1

            });

            cars.Add(new CarEntity()
            {
                Id = 3,
                Brand = "Subaru",
                Model = "Legacy",
                Price = 18000,
                //DealerId = 2

            });

            cars.Add(new CarEntity()
            {
                Id = 4,
                Brand = "Jeep",
                Model = "Cherokee",
                Price = 25000,
                //DealerId = 2

            });
        }

        public void CreateCar(CarEntity newCar)
        {
            dbContext.Entry(newCar.Dealer).State = EntityState.Unchanged;
            dbContext.Cars.Add(newCar);

        }

        public void CreateDealer(DealerEntity newDealer)
        {
            dbContext.Dealers.Add(newDealer);

        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            var car = await GetCarAsync(id);
            dbContext.Cars.Remove(car);
            return true;
        }

        public async Task<bool> DeleteDealer(int id)
        {
            var dealerDelete = await dbContext.Dealers.FirstOrDefaultAsync(d => d.Id == id);
            dbContext.Dealers.Remove(dealerDelete);
            return true;
        }

        public async Task<CarEntity> GetCarAsync(int id)
        {
            IQueryable<CarEntity> query = dbContext.Cars;
            query = query.Include(c => c.Dealer);
            query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CarEntity>> GetCarsAsync(int dealerId)
        {
            IQueryable<CarEntity> query = dbContext.Cars;
            query = query.AsNoTracking();
            return await query.ToArrayAsync();
        }

        public async Task <DealerEntity> GetDealerAsync(int id, bool showCars = false)
        {
            IQueryable<DealerEntity> query = dbContext.Dealers;
            query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<DealerEntity>> GetDealersAsync(string orderBy, bool showCars = false)
        {
            IQueryable<DealerEntity> query = dbContext.Dealers;

            var dealer = query.FirstOrDefault();

            switch (orderBy)
            {
                case "id":
                    query = query.OrderBy(r => r.Id);
                    break;
                case "name":
                    query = query.OrderBy(r => r.Name);
                    break;
                case "address":
                    query = query.OrderBy(r => r.Address);
                    break;
                default:
                    break;
            }

            if (showCars)
            {
                query = query.Include(d => d.Cars);
            }

            query = query.AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            var res = await dbContext.SaveChangesAsync();
            return res > 0;
        }

        public bool UpdateCar(CarEntity car)
        {
            dbContext.Entry(car.Dealer).State = EntityState.Unchanged;
            dbContext.Cars.Update(car);
            return true;

        }
        public bool UpdateDealer(DealerEntity dealer)
        {
            dbContext.Dealers.Update(dealer);
            return true;
        }

    }
}
