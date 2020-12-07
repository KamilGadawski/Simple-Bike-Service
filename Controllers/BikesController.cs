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

        [HttpGet("search")]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<BikeDto>>> GetBikes([FromQuery]string brand)
        {
            var brandResult = await _bikeCustomersRepository.GetBikes(brand);
            return Ok(_mapper.Map<IEnumerable<BikeDto>>(brandResult));
        }

        [HttpGet("{bikeId}", Name ="GetBike")]
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

        [HttpPost]
        public async Task<ActionResult<BikeDto>> CreateBike([FromBody] BikeCreatingDto bike)
        {
            var bikeEntity = _mapper.Map<Entities.Bike>(bike);

            await _bikeCustomersRepository.AddBike(bikeEntity);
            _bikeCustomersRepository.Save();

            var bikeReturn = _mapper.Map<BikeDto>(bikeEntity);

            return CreatedAtRoute("GetBike", new { bikeId = bikeReturn.Id }, bikeReturn);
        }
    }
}

