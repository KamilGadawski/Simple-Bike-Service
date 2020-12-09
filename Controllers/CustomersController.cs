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
        [HttpHead]
        public async Task<ActionResult<IEnumerable<CustomersDto>>> GetCustomer([FromQuery]string name, [FromQuery]string surname)
        {
            var searchCustomer = await _bikeCustomersRepository.GetCustomer(name, surname);
            return Ok(_mapper.Map<IEnumerable<CustomersDto>>(searchCustomer));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CustomersDto>>> GetCustomers()
        {
            var customers = await _bikeCustomersRepository.GetCustomers();
            return Ok(_mapper.Map<IEnumerable<CustomersDto>>(customers));
        }

        [HttpGet("{customerId}", Name ="GetCustomer")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            if (customerId == null)
            {
                return NotFound(customerId);
            }

            if (!await _bikeCustomersRepository.CustomerExist(customerId))
            {
                return NotFound(customerId);
            }

            var customer = await _bikeCustomersRepository.GetCustomer(customerId);

            return Ok(_mapper.Map<CustomersDto>(customer));
        }

        [HttpGet]
        [Route("{customerId}/bikes")]
        public async Task<ActionResult<IEnumerable<BikeDto>>> GetBikesForCustomer(Guid customerId)
        {
            if (!await _bikeCustomersRepository.CustomerExist(customerId))
            {
                return NotFound(customerId);
            }

            var bikes = await _bikeCustomersRepository.GetBikesForCustomer(customerId);
            return Ok(_mapper.Map<IEnumerable<BikeDto>>(bikes));
        }

        [HttpPost]
        public async Task<ActionResult<CustomersDto>> CreateCustomer([FromBody] CustomerCreatingDto customer)
        {
            DateTime time = DateTime.Now;

            var customerEntity = _mapper.Map<Entities.Customer>(customer);
            customerEntity.DateTimeAdd = time;

            await _bikeCustomersRepository.AddCustomer(customerEntity);
            await _bikeCustomersRepository.Save();

            var customerReturn = _mapper.Map<CustomersDto>(customerEntity);

            return CreatedAtRoute("GetCustomer", new { customerId = customerReturn.Id }, customerReturn);
        }
    }
}
