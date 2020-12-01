using Microsoft.EntityFrameworkCore;
using ServiceAPI.DbContexts;
using ServiceAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPI.Services
{
    public class BikeCustomerRepository : IBikeCustomersRepository
    {
        private readonly BikeCustomerContext _context;

        public BikeCustomerRepository(BikeCustomerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddBike(Bike bike)
        {
            if (bike == null)
            {
                throw new ArgumentNullException(nameof(bike));
            }

            _context.Bikes.Add(bike);
        }

        public void AddCustomer(Guid bikeId, Customer customer)
        {
            if (bikeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(bikeId));
            }

            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            customer.BikeId = bikeId;
            _context.Customers.Add(customer);
        }

        public async Task<bool> BikeExist(Guid bikeId)
        {
            if (bikeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(bikeId));
            }

            return await _context.Bikes.AnyAsync(x => x.Id == bikeId);
        }

        public async Task<bool> CustomerExist(Guid customerId)
        {
            if (customerId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(customerId));
            }

            var exist = await _context.Customers.AnyAsync(x => x.Id == customerId);
            return exist;
        }

        public void DeleteBike(Bike bike)
        {
            if (bike == null)
            {
                throw new ArgumentNullException(nameof(bike));
            }

            _context.Bikes.Remove(bike);
        }

        public void DeleteCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            _context.Customers.Remove(customer);
        }

        public async Task<IEnumerable<Bike>> GetBikes()
        {
            return await _context.Bikes.ToListAsync();
        }

        public async Task<Bike> GetBike(Guid bikeId)
        {
            if (bikeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(bikeId));
            }

            return await _context.Bikes.FirstOrDefaultAsync(x => x.Id == bikeId);
        }

        public async Task<IEnumerable<Bike>> GetBikesForCustomer(Guid customerId)
        {
            if (customerId == null)
            {
                throw new ArgumentNullException(nameof(customerId));
            }

            var bikes = await _context.Bikes.Where(x => x.CustomerID == customerId)
                                              .OrderBy(x => x.Brand).ToListAsync();
            return bikes;
        }

        //public IEnumerable<Bike> GetBikes(IEnumerable<Guid> bikeIds)
        //{
        //    if (bikeIds == null)
        //    {
        //        throw new ArgumentNullException(nameof(bikeIds));
        //    }

        //    return _context.Bikes.Where(x => bikeIds.Contains(x.Id))
        //                         .OrderBy(x => x.Brand).ToList();
        //}

        public IEnumerable<Customer> GetCustomer(Guid bikeId)
        {
            if (bikeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(bikeId));
            }

            return _context.Customers.Where(x => x.BikeId == bikeId)
                                     .OrderBy(x => x.Name).ToList();
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public Customer GetCustomer(Guid bikeId, Guid customerId)
        {
            if (bikeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(bikeId));
            }

            if (customerId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(customerId));
            }

            return _context.Customers.Where(x => x.BikeId == bikeId && x.Id == customerId).FirstOrDefault();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateBike(Bike bike)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
