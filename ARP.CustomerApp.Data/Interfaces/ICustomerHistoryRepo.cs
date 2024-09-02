using System;
using System.Threading.Tasks;

namespace ARP.CustomerApp.Data.Interfaces
{
    public interface ICustomerHistoryRepo
    {
        /// <summary>
        /// Creates a new customer history record
        /// </summary>
        /// <param name="customerID">The CustomerID of the Customer that this record refers to</param>
        /// <param name="editDate">The date that the edit was made</param>
        /// <returns></returns>
        Task<int> CreateAsync(int customerID, DateTime editDate);

        /// <summary>
        /// Deletes all history for a customer
        /// </summary>
        /// <param name="customerID">The CustomerID of the Customer. Who would have guessed. I don't normally doc params but I'm going overboard...</param>
        /// <returns></returns>
        Task DeleteForCustomerAsync(int customerID);
    }
}
