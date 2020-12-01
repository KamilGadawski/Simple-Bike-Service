using ServiceAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPI.Services
{
    public interface IBikeCustomersRepository
    {
        IEnumerable<Customer> GetCustomer(Guid bikeId);
        Task<IEnumerable<Customer>> GetCustomers();
        Customer GetCustomer(Guid bikeId, Guid customerId);
        void AddCustomer(Guid bikeId, Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        Task<IEnumerable<Bike>> GetBikes();
        Task<Bike> GetBike(Guid bikeId);
        Task<IEnumerable<Bike>> GetBikesForCustomer(Guid customerId);
        //Task<IEnumerable<Bike>> GetBikes(IEnumerable<Guid> bikeIds);
        void AddBike(Bike bike);
        void UpdateBike(Bike bike);
        void DeleteBike(Bike bike);
        Task<bool> BikeExist(Guid bikeId);
        Task<bool> CustomerExist(Guid customerId);
        bool Save();
    }
}
