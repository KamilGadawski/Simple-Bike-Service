using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceAPI.Services;
using ServiceAPI.Models;

namespace ServiceAPI.Controllers
{
    [ApiController]
    [Route("API/bikes")]
    public class BikesController : ControllerBase
    {
        private readonly IBikeCustomersRepository _bikeCustomersRepository;

        public BikesController(IBikeCustomersRepository bikeCustomersRepository)
        {
            _bikeCustomersRepository = bikeCustomersRepository ?? throw new ArgumentNullException(nameof(bikeCustomersRepository));
        }

        [HttpGet]
        public IActionResult GetBikes()
        {
            var bikes = _bikeCustomersRepository.GetBikes();
            var bikesDto = new List<BikeDto>();

            foreach(var bike in bikes)
            {
                bikesDto.Add(new BikeDto()
                {
                    Id = bike.Id,
                    Brand = bike.Brand,
                    Model = bike.Model,
                    Size = bike.Size,
                    Description = bike.Description,
                    AddedBikeAgo = $"{bike.AddedBike:MM/dd/yyyy HH:mm}"
                });
            }
            return Ok(bikesDto);
        }

        [HttpGet("{bikeId}")]
        public IActionResult GetBike(Guid bikeId)
        {
            var bike = _bikeCustomersRepository.GetBike(bikeId);

            if (bike == null)
            {
                return NotFound();
            }
            return Ok(bike);
        }
    }
}

