using ARP.CustomerApp.API.Services.Interfaces;
using ARP.CustomerApp.Data.Interfaces;
using ARP.CustomerApp.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARP.CustomerApp.API.Services.UOW
{
    public class CustomerDeleteUOW(ILogger<CustomerCreateUOW> logger,
        ICustomerRepo customerRepo,
        ICustomerHistoryRepo customerHistoryRepo) : ICustomerDeleteUOW
    {
        private readonly ILogger<CustomerCreateUOW> _logger = logger;
        private readonly ICustomerRepo _customerRepo = customerRepo;
        private readonly ICustomerHistoryRepo _customerHistoryRepo = customerHistoryRepo;

        public async Task DeleteAsync(int customerID)
        {
            try
            {
                await _customerRepo.DeleteAsync(customerID);

                await _customerHistoryRepo.DeleteForCustomerAsync(customerID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CustomerDeleteUOW failed");
                throw;
            }
        }
    }
}
