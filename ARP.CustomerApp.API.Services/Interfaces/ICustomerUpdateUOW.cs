using ARP.CustomerApp.Entity;
using System.Threading.Tasks;

namespace ARP.CustomerApp.API.Services.Interfaces
{
    public interface ICustomerUpdateUOW
    {
        Task<Customer> UpdateAsync(Customer customer);
    }
}