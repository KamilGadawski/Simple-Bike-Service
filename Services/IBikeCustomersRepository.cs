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
        Customer GetCustomer(Guid bikeId, Guid customerId);
        void AddCustomer(Guid bikeId, Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);

        IEnumerable<Bike> GetBikes();
        Bike GetBike(Guid bikeId);
        IEnumerable<Bike> GetBikesForCustomer(Guid customerId);
        IEnumerable<Bike> GetBikes(IEnumerable<Guid> bikeIds);
        void AddBike(Bike bike);
        void UpdateBike(Bike bike);
        void DeleteBike(Bike bike);

        bool BikeExist(Guid bikeId);
        bool CustomerExist(Guid customerId);
        bool Save();
    }
}
