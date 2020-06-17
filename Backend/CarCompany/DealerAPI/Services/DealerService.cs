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

        public DealerModel CreateDealer(DealerModel newDealer)
        {
            var dealerEntity = mapper.Map<DealerEntity>(newDealer);
            var newDealerEntity = repository.CreateDealer(dealerEntity);
            return mapper.Map<DealerModel>(newDealerEntity);
        }

        public bool DeleteDealer(int id)
        {
            var dealerToDelete = GetDealer(id);
            repository.DeleteDealer(id);
            return true;
        }

        public DealerModel GetDealer(int id)
        {
            var resturantEntity = repository.GetDealer(id);
            if (resturantEntity == null)
            {
                throw new NotFoundException($"the id :{id} not exist");
            }
            else
            {
                return mapper.Map<DealerModel>(resturantEntity); ;
            }

        }

        public IEnumerable<DealerModel> GetDealers(string orderBy)
        {
            if (!allowedSortValues.Contains(orderBy.ToLower()))
            {
                throw new BadOperationRequest($"bad sort value: { orderBy } allowed values are: { String.Join(",", allowedSortValues)}");
            }
            var dealerEntities = repository.GetDealers(orderBy);
            return mapper.Map<IEnumerable<DealerModel>>(dealerEntities);
        }

        public bool UpdateDealer(int id, DealerModel dealer)
        {
            GetDealer(id);
            dealer.Id = id;

            repository.UpdateDealer(mapper.Map<DealerEntity>(dealer));
            return true;
        }
    }
}
