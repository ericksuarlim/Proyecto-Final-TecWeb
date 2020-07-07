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
    public class DealerService : IDealerService
    {

        private List<string> allowedSortValues = new List<string>() { "id", "name", "address" };
        private IDealerRepository repository;
        private readonly IMapper mapper;

        public DealerService(IDealerRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DealerModel> CreateDealerAsync(DealerModel newDealer)
        {
            var dealerEntity = mapper.Map<DealerEntity>(newDealer);
            repository.CreateDealer(dealerEntity);
            var res = await repository.SaveChangesAsync();
            if (res)
            { 
                return mapper.Map<DealerModel>(dealerEntity);
            }

            throw new Exception("Database exception");
        }

        public async Task<bool> DeleteDealerAsync(int id)
        {
            var dealerToDelete = await GetDealerAsync(id);
            await repository.DeleteDealer(id);

            var deal = await repository.SaveChangesAsync();
            if (deal)
            {
                return true;
            }

            throw new Exception("Database Exception");

        }

        public async Task<DealerModel> GetDealerAsync(int id)
        {
            var resturantEntity = await repository.GetDealerAsync(id);
            if (resturantEntity == null)
            {
                throw new NotFoundException($"the id :{id} not exist");
            }
            else
            {
                return mapper.Map<DealerModel>(resturantEntity); ;
            }

        }

        public async Task<IEnumerable<DealerModel>> GetDealersAsync(string orderBy, bool showCars)
        {
            if (!allowedSortValues.Contains(orderBy.ToLower()))
            {
                throw new BadOperationRequest($"bad sort value: { orderBy } allowed values are: { String.Join(",", allowedSortValues)}");
            }
            var dealerEntities = await repository.GetDealersAsync(orderBy, showCars);
            return mapper.Map<IEnumerable<DealerModel>>(dealerEntities);
        }

        public async Task<bool> UpdateDealerAsync(int id, DealerModel dealer)
        {
            await GetDealerAsync(id);
            dealer.Id = id;

            repository.UpdateDealer(mapper.Map<DealerEntity>(dealer));
            var deal = await repository.SaveChangesAsync();
            if (deal)
            {
                return true;
            }

            throw new Exception("Database Exception");
        }
    }
}
