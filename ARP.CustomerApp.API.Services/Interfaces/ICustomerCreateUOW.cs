using ARP.CustomerApp.Entity;
using System;
using System.Threading.Tasks;

namespace ARP.CustomerApp.API.Services.Interfaces
{
    public interface ICustomerCreateUOW
    {
        Task<Customer> CreateAsync(Customer customer);
    }
}