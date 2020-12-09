using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPI.Profiles
{
    public class CustomerProfile: Profile
    {
        public CustomerProfile()
        {
            CreateMap<Entities.Customer, Models.CustomersDto>();
            CreateMap<Models.CustomerCreatingDto, Entities.Customer>();
        }
    }
}
