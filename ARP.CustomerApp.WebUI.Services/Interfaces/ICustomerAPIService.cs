using ARP.CustomerApp.Entity;
using ARP.CustomerApp.WebUI.Services.Result;
using System.Threading.Tasks;

namespace ARP.CustomerApp.WebUI.Services.Interfaces
{
    public interface ICustomerAPIService
    {
        Task<CustomerCreateResult> CreateCustomerAsync(Customer customer);
        Task<CustomerDeleteResult> DeleteCustomerAsync(int customerID);
        Task<CustomerGetResult> GetCustomerAsync(int customerID);
        Task<CustomerListResult> ListAsync(string keyword);
        Task<CustomerUpdateResult> UpdateCustomerAsync(Customer customer);
    }
}