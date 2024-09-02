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
    public class CustomerCreateUOW(ILogger<CustomerCreateUOW> logger,
        ICustomerRepo customerRepo,
        ICustomerHistoryRepo customerHistoryRepo,
        IDateTimeService dateTimeService) : ICustomerCreateUOW
    {
        private readonly ILogger<CustomerCreateUOW> _logger = logger;
        private readonly ICustomerRepo _customerRepo = customerRepo;
        private readonly ICustomerHistoryRepo _customerHistoryRepo = customerHistoryRepo;
        private readonly IDateTimeService _dateTimeService = dateTimeService;

        public async Task<Customer> CreateAsync(Customer customer)
        {
            try
            {
                int customerID = await _customerRepo.CreateAsync(customer);

                await _customerHistoryRepo.CreateAsync(customerID, _dateTimeService.CurrentDateTime);

                return await _customerRepo.GetAsync(customerID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CustomerCreateUOW failed");
                throw;
            }
        }
    }
}
