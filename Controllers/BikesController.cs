using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceAPI.Services;
using ServiceAPI.Models;
using ServiceAPI.Helpers;
using AutoMapper;
using System.Text.Json;

namespace ServiceAPI.Controllers
{
    [ApiController]
    [Route("API/bikes")]
    public class BikesController : ControllerBase
    {
        private readonly IBikeCustomersRepository _bikeCustomersRepository;
        private readonly IMapper _mapper;

        public BikesController(IBikeCustomersRepository bikeCustomersRepository, IMapper mapper)
        {
            _bikeCustomersRepository = bikeCustomersRepository ?? throw new ArgumentNullException(nameof(bikeCustomersRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BikeDto>>> GetBikes()
        {
            var bikes = await _bikeCustomersRepository.GetBikes();
            return Ok(_mapper.Map<IEnumerable<BikeDto>>(bikes));
        }

        [HttpGet("{bikeId}")]
        public async Task<IActionResult> GetBike(Guid bikeId)
        {
            var bike = await _bikeCustomersRepository.GetBike(bikeId);
            if (!await _bikeCustomersRepository.BikeExist(bikeId))
            {
                return NotFound(bikeId);
            }

            if (bike == null)
            {
                return NotFound(bike);
            }
            return Ok(_mapper.Map<BikeDto>(bike));
        }
    }
}

