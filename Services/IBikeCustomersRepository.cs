using ServiceAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPI.Services
{
    public interface IBikeCustomersRepository
    {
        IEnumerable<Bike> GetBike(Guid bikeId);
        Bike GetBike(Guid bikeId, Guid customerId);
        void AddBike(Guid bikeId, Customer customer);
        void UpdateBike(Bike bike);
        void DeleteBike(Bike bike);

        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(Guid customerId);
        IEnumerable<Customer> GetCustomers(IEnumerable<Guid> customerId);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);

        bool BikeExist(Guid bikeId);
        bool CustomerExist(Guid customerId);
        bool Save();
    }
}
