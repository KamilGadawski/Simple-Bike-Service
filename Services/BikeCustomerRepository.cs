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
        public async Task AddBike(Bike bike)
        {
            if (bike == null)
            {
                throw new ArgumentNullException(nameof(bike));
            }

          await _context.Bikes.AddAsync(bike);
        }

        public async Task AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            
            await _context.Customers.AddAsync(customer);
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

        public async Task<IEnumerable<Bike>> GetBikes(string brand)
        {
            brand = brand.Trim();

            if(string.IsNullOrEmpty(brand))
            {
                return await GetBikes();
            }

            var searchBrand = _context.Bikes as IQueryable<Bike>;

            return await searchBrand.Where(x => x.Brand.Contains(brand)).ToListAsync();
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

        public async Task<Customer> GetCustomer(Guid customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.Id == customerId);
        }

        public async Task<IEnumerable<Customer>> GetCustomer(string name, string surname)
        {

            if(string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(surname))
            {
                return await GetCustomers();
            }

            var customerCollection = _context.Customers as IQueryable<Customer>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                customerCollection = customerCollection.Where(x => x.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(surname))
            {
                surname = surname.Trim();
                customerCollection = customerCollection.Where(x => x.Surname == surname);
            }

            return await customerCollection.ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync() >= 0);
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
