using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceAPI.Services;
using ServiceAPI.Models;
using ServiceAPI.Helpers;
using AutoMapper;

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
        public ActionResult<IEnumerable<BikeDto>> GetBikes()
        {
            var bikes = _bikeCustomersRepository.GetBikes();
            return Ok(_mapper.Map<IEnumerable<BikeDto>>(bikes));
        }

        [HttpGet("{bikeId}")]
        public IActionResult GetBike(Guid bikeId)
        {
            //if(_bikeCustomersRepository.BikeExist(bikeId))
            //{
            //    return NotFound();
            //}

            var bike = _bikeCustomersRepository.GetBike(bikeId);
            if (bike == null)
            {
                return NotFound();
            }
            return Ok(bike);
        }
    }
}

