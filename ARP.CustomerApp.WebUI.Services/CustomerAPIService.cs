using ARP.CustomerApp.Entity;
using ARP.CustomerApp.WebUI.Services.Interfaces;
using ARP.CustomerApp.WebUI.Services.Result;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ARP.CustomerApp.WebUI.Services
{
    public class CustomerAPIService(ILogger<CustomerAPIService> logger,
        IHttpClientFactory httpClientFactory) : ICustomerAPIService
    {
        private readonly ILogger<CustomerAPIService> _logger = logger;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

        public async Task<CustomerListResult> ListAsync(string keyword)
        {
            string url = $"customer" + (String.IsNullOrWhiteSpace(keyword) ? "" : $"?keyword={keyword}");
            using HttpClient client = _httpClientFactory.CreateClient(Consts.HTTPCLIENT_NAME_CUSTOMERAPP_API);
            var result = new CustomerListResult();

            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var customers = await response.Content.ReadFromJsonAsync<List<Customer>>();
                    result.Success = true;
                    result.Customers = customers;
                }
                else
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                    result.Success = false;
                    result.ErrorMessage = errorResponse.Message;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during List Customers");
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving the list of customers";
            }

            return result;
        }

        public async Task<CustomerGetResult> GetCustomerAsync(int customerID)
        {
            string url = $"customer/{customerID}";
            using HttpClient client = _httpClientFactory.CreateClient(Consts.HTTPCLIENT_NAME_CUSTOMERAPP_API);

            var result = new CustomerGetResult();

            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    result.Customer = await response.Content.ReadFromJsonAsync<Customer>();
                    result.Success = true;
                }
                else
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                    result.Success = false;
                    result.ErrorMessage = errorResponse.Message;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during Get Customer");
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving the customer";
            }

            return result;
        }

        public async Task<CustomerUpdateResult> UpdateCustomerAsync(Customer customer)
        {
            string url = $"customer";
            using HttpClient client = _httpClientFactory.CreateClient(Consts.HTTPCLIENT_NAME_CUSTOMERAPP_API);

            var result = new CustomerUpdateResult();

            try
            {
                var content = JsonContent.Create(customer);
                var response = await client.PutAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var customerUpdated = await response.Content.ReadFromJsonAsync<Customer>();
                    result.Success = true;
                }
                else
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                    result.Success = false;
                    result.ErrorMessage = errorResponse.Message;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during Update Customer");
                result.Success = false;
                result.ErrorMessage = "An error occurred while updating the customer";
            }

            return result;
        }

        public async Task<CustomerCreateResult> CreateCustomerAsync(Customer customer)
        {
            string url = $"customer";
            using HttpClient client = _httpClientFactory.CreateClient(Consts.HTTPCLIENT_NAME_CUSTOMERAPP_API);

            var result = new CustomerCreateResult();

            try
            {
                var content = JsonContent.Create(customer);
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var customerCreated = await response.Content.ReadFromJsonAsync<Customer>();
                    result.Success = true;
                    result.CustomerID = customerCreated.CustomerID;
                }
                else
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                    result.Success = false;
                    result.ErrorMessage = errorResponse.Message;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during Update Customer");
                result.Success = false;
                result.ErrorMessage = "An error occurred while updating the customer";
            }

            return result;
        }

        public async Task<CustomerDeleteResult> DeleteCustomerAsync(int customerID)
        {
            string url = $"customer/{customerID}";
            using HttpClient client = _httpClientFactory.CreateClient(Consts.HTTPCLIENT_NAME_CUSTOMERAPP_API);

            var result = new CustomerDeleteResult();

            try
            {
                var response = await client.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                }
                else
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                    result.Success = false;
                    result.ErrorMessage = errorResponse.Message;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during Get Customer");
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving the customer";
            }

            return result;
        }
    }
}
