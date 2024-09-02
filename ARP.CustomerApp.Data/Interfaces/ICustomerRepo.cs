using ARP.CustomerApp.Data.Options;
using ARP.CustomerApp.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARP.CustomerApp.Data.Interfaces
{
    public interface ICustomerRepo
    {
        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="customer">The Customer model</param>
        /// <returns>The newly created CustomerID</returns>
        Task<int> CreateAsync(Customer customer);

        /// <summary>
        /// Deletes an existing customer via its CustomerID
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        Task DeleteAsync(int customerID);

        /// <summary>
        /// Retrieves a single Customer via its CustomerID
        /// </summary>
        /// <param name="customerID">The CustomerID of the Customer to delete</param>
        /// <returns></returns>
        Task<Customer> GetAsync(int customerID);

        /// <summary>
        /// Lists Customers with optional search parameters
        /// </summary>
        /// <param name="searchOptions"></param>
        /// <returns>The applicable list of customers</returns>
        Task<IEnumerable<Customer>> ListAsync(CustomerSearchOptions searchOptions);

        /// <summary>
        /// Updates an existing Customer
        /// </summary>
        /// <param name="customer">The Customer model to update</param>
        /// <returns></returns>
        Task UpdateAsync(Customer customer);
    }
}