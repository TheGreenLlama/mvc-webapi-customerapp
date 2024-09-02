using ARP.CustomerApp.API.Models;
using ARP.CustomerApp.API.Services.Interfaces;
using ARP.CustomerApp.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARP.CustomerApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController(ILogger<CustomerController> logger, ICustomerService customerService) : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger = logger;
        private readonly ICustomerService _customerService = customerService;

        /// <summary>
        /// Retrieves a single Customer
        /// </summary>
        /// <param name="id">The CustomerID</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var customer = await _customerService.GetByIDAsync(id);
                if (customer != null) { return Ok(customer); }

                return NotFound(new ErrorResponse { Message = "The specific client was not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to retrieve customer");
                return Build500Error("A technical error occurred while retrieving the customer details");
            }
        }

        /// <summary>
        /// Retrieves the list of Customers
        /// </summary>
        /// <param name="keyword">Optionally searches by keyword</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Customer>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Index([FromQuery] string keyword = null)
        {
            try
            {
                return Ok(await _customerService.ListCustomersAsync(keyword));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to retrieve customer list");
                return Build500Error("A technical error occurred while retrieving the customer list");
            }
        }

        /// <summary>
        /// Creates a new Customer
        /// </summary>
        /// <param name="customer">The Customer details</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            try
            {
                var customerCreated = await _customerService.CreateCustomerAsync(customer);
                return CreatedAtAction(nameof(Get), new { id = customerCreated.CustomerID }, customerCreated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to create the customer");
                return Build500Error("A technical error occurred while creating the customer");
            }
        }

        /// <summary>
        /// Updates an existing Customer
        /// </summary>
        /// <param name="customer">The Customer details</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] Customer customer)
        {
            try
            {
                var customerUpdated = await _customerService.UpdateCustomerAsync(customer);
                return Ok(customerUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to update the customer");
                return Build500Error("A technical error occurred while updating the customer");
            }
        }

        /// <summary>
        /// Deletes a Customer and its History
        /// </summary>
        /// <param name="id">The CustomerID</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to delete the customer");
                return Build500Error("A technical error occurred while deleting the customer");
            }
        }

        private IActionResult Build500Error(string errorMessage)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = errorMessage });
        }
    }
}

