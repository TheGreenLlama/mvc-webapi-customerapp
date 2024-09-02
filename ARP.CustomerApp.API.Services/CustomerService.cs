using ARP.CustomerApp.API.Services.Interfaces;
using ARP.CustomerApp.API.Services.UOW;
using ARP.CustomerApp.Data.Interfaces;
using ARP.CustomerApp.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace ARP.CustomerApp.API.Services
{
    public class CustomerService(ILogger<CustomerService> logger, 
        ICustomerRepo customerRepo, 
        ICustomerCreateUOW customerCreateUOW,
        ICustomerUpdateUOW customerUpdateUOW,
        ICustomerDeleteUOW customerDeleteUOW) : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger = logger;
        private readonly ICustomerRepo _customerRepo = customerRepo;
        private readonly ICustomerCreateUOW _customerCreateUOW = customerCreateUOW;
        private readonly ICustomerUpdateUOW _customerUpdateUOW = customerUpdateUOW;
        private readonly ICustomerDeleteUOW _customerDeleteUOW = customerDeleteUOW;

        public async Task<Customer> GetByIDAsync(int customerID)
        {
            try
            {
                return await _customerRepo.GetAsync(customerID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Customer Service GetByID failed");
                throw;
            }
        }

        public async Task<IEnumerable<Customer>> ListCustomersAsync(string keyword)
        {
            try
            {
                return await _customerRepo.ListAsync(new Data.Options.CustomerSearchOptions { Keyword = keyword });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Customer Service list failed");
                throw;
            }
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var customerCreated = await _customerCreateUOW.CreateAsync(customer);
                    transaction.Complete();

                    return customerCreated;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Customer Service create failed");
                throw;
            }
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var customerUpdated = await _customerUpdateUOW.UpdateAsync(customer);
                    transaction.Complete();

                    return customerUpdated;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Customer Service update failed");
                throw;
            }
        }

        public async Task DeleteCustomerAsync(int customerID)
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await _customerDeleteUOW.DeleteAsync(customerID);
                    transaction.Complete();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Customer Service delete failed");
                throw;
            }
        }

    }
}
