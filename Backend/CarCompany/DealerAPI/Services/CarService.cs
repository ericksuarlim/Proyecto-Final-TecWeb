using AutoMapper;
using DealerAPI.Data.Entities;
using DealerAPI.Data.Repository;
using DealerAPI.Exceptions;
using DealerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerAPI.Services
{
    public class CarService : ICarService
    {
        private IDealerRepository repository;
        private IMapper mapper;

        public CarService(IDealerRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<CarModel> CreateCarAsync(int DealerId, CarModel newCar)
        {
            await ValidateDealerAsync(DealerId);
            newCar.DealerId = DealerId;
            var carEntity = mapper.Map<CarEntity>(newCar);
            
            repository.CreateCar(carEntity);

            var deal = await repository.SaveChangesAsync();
            if (deal)
            {
                return mapper.Map<CarModel>(carEntity);
            }

            throw new Exception("Database Exception");
            
        }

        public async Task<bool> DeleteCarAsync(int dealerId, int id)
        {
            var car = await GetCarAsync(dealerId, id);
            if (car == null)
            {
                throw new NotFoundException($"The car with {id} does not exist in the dealership.");
            }
            await repository.DeleteCarAsync(id);
            var deal = await repository.SaveChangesAsync();

            if (deal)
            {
                return true;
            }

            throw new Exception("Database Exception");
        }

        public async Task<CarModel> GetCarAsync(int DealerId, int id)
        {
            await ValidateDealerAsync(DealerId);
            var car = await repository.GetCarAsync(id);

            if (car == null || car.Dealer.Id != DealerId)
            {
                throw new NotFoundException($"The id :{id} doesn't exist.");
            }

            return mapper.Map<CarModel>(car);
        }

        public async Task<IEnumerable<CarModel>> GetCarsAsync(int dealerId)
        {
            await ValidateDealerAsync(dealerId);
            return mapper.Map<IEnumerable<CarModel>>(await repository.GetCarsAsync(dealerId));
        }

        public async Task<bool> UpdateCarAsync(int dealerId, int id, CarModel car)
        {
            car.Id = id;
            await GetCarAsync(dealerId, id);

            repository.UpdateCar(mapper.Map<CarEntity>(car));

            var deal = await repository.SaveChangesAsync();
            if (deal)
            {
                return true;
            }

            throw new Exception("Database Exception");
        }

        private async Task ValidateDealerAsync(int id)
        {
            var dealerEntity = await repository.GetDealerAsync(id);
            if (dealerEntity == null)
            {
                throw new NotFoundException($"the id :{id} does not exist for dealer");
            }
        }
    }
}
