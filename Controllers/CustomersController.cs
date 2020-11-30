using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceAPI.Models;
using ServiceAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPI.Controllers
{
    [ApiController]
    [Route("API/customer")]
    public class CustomersController : ControllerBase
    {
        private readonly IBikeCustomersRepository _bikeCustomersRepository;
        private readonly IMapper _mapper;

        public CustomersController(IBikeCustomersRepository bikeCustomersRepository, IMapper mapper)
        {
            _bikeCustomersRepository = bikeCustomersRepository ?? throw new ArgumentNullException(nameof(bikeCustomersRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("{customerId}/bikes")]
        public ActionResult<IEnumerable<BikeDto>> GetBikesForCustomer(Guid customerId)
        {
            if (!_bikeCustomersRepository.CustomerExist(customerId))
            {
                return NotFound();
            }

            var bikes = _bikeCustomersRepository.GetBikesForCustomer(customerId);
            return Ok(_mapper.Map<IEnumerable<BikeDto>>(bikes));
        }
    }
}
