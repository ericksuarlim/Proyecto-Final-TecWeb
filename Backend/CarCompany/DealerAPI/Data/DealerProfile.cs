using AutoMapper;
using DealerAPI.Data.Entities;
using DealerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerAPI.Data
{
    public class DealerProfile : Profile
    {
        public DealerProfile()
        {
            this.CreateMap<DealerEntity, DealerModel>()
                .ReverseMap();
            this.CreateMap<CarEntity, CarModel>()
               .ReverseMap();
        }
    }
}
