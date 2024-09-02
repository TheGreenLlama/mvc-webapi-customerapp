using System.Threading.Tasks;

namespace ARP.CustomerApp.API.Services.Interfaces
{
    public interface ICustomerDeleteUOW
    {
        Task DeleteAsync(int customerID);
    }
}