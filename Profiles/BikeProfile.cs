using AutoMapper;
using ServiceAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPI.Profiles
{
    public class BikeProfile : Profile
    {
        public BikeProfile()
        {
            CreateMap<Entities.Bike, Models.BikeDto>()
                .ForMember(
                x => x.AddedBikeAgo,
                option => option.MapFrom(src => $"{src.AddedBike.ToString("MM/dd/yyyy")} ({src.AddedBike.AddedBikeAgo()})")
                );

            CreateMap<Models.BikeCreatingDto, Entities.Bike>();
        }
    }
}
