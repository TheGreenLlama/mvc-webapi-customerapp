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
    public class CustomerUpdateUOW(ILogger<CustomerUpdateUOW> logger,
        ICustomerRepo customerRepo,
        ICustomerHistoryRepo customerHistoryRepo,
        IDateTimeService dateTimeService) : ICustomerUpdateUOW
    {
        private readonly ILogger<CustomerUpdateUOW> _logger = logger;
        private readonly ICustomerRepo _customerRepo = customerRepo;
        private readonly ICustomerHistoryRepo _customerHistoryRepo = customerHistoryRepo;
        private readonly IDateTimeService _dateTimeService = dateTimeService;

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            try
            {
                await _customerRepo.UpdateAsync(customer);

                await _customerHistoryRepo.CreateAsync(customer.CustomerID, _dateTimeService.CurrentDateTime);

                return await _customerRepo.GetAsync(customer.CustomerID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CustomerUpdateUOW failed");
                throw;
            }
        }
    }
}
