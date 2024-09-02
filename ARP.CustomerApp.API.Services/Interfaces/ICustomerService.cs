using ARP.CustomerApp.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARP.CustomerApp.API.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int customerID);
        Task<Customer> GetByIDAsync(int customerID);
        Task<IEnumerable<Customer>> ListCustomersAsync(string keyword);
        Task<Customer> UpdateCustomerAsync(Customer customer);
    }
}