using ServiceAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPI.Services
{
    public interface IBikeCustomersRepository
    {
        Task<Customer> GetCustomer(Guid customerId);
        Task<IEnumerable<Customer>> GetCustomer(string name, string surname);
        Task<IEnumerable<Customer>> GetCustomers();
        Customer GetCustomer(Guid bikeId, Guid customerId);
        void AddCustomer(Guid bikeId, Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        Task<IEnumerable<Bike>> GetBikes();
        Task<IEnumerable<Bike>> GetBikes(string brand);
        Task<Bike> GetBike(Guid bikeId);
        Task<IEnumerable<Bike>> GetBikesForCustomer(Guid customerId);
        Task AddBike(Bike bike);
        void UpdateBike(Bike bike);
        void DeleteBike(Bike bike);
        Task<bool> BikeExist(Guid bikeId);
        Task<bool> CustomerExist(Guid customerId);
        bool Save();
    }
}
