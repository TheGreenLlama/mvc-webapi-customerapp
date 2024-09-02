using ARP.CustomerApp.Entity;
using ARP.CustomerApp.WebUI.Services.Interfaces;
using ARP.CustomerApp.WebUI.Services.Result;
using Microsoft.AspNetCore.Mvc;

namespace ARP.CustomerApp.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        // NOTE - i would normally have try...catch blocks around these API calls as Exceptions if exceptions are passed up the chain. The UI would then respond accordingly
        // i.e. a banner for minor errors (with retry etc. where applicable) or redirect to a 'catastrophic' error page.

        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerAPIService _customerAPIService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerAPIService customerAPIService)
        {
            _logger = logger;
            _customerAPIService = customerAPIService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _customerAPIService.ListAsync(null);
            if (!result.Success) return Error(result.ErrorMessage);
            return View(result.Customers);
        }

        public IActionResult Create()
        {
            var customer = new Customer();
            return View("Edit", customer);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            if (id > 0)
            {
                var result = await _customerAPIService.GetCustomerAsync(id);
                if (!result.Success) return Error(result.ErrorMessage);
                return View(result.Customer);
            }
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);

            ResultBase result;

            if (customer.CustomerID > 0)
            {
                result = await _customerAPIService.UpdateCustomerAsync(customer);
            }
            else
            {
                result = await _customerAPIService.CreateCustomerAsync(customer);
            }

            if (!result.Success) return Error(result.ErrorMessage);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customerAPIService.GetCustomerAsync(id);
            if (!result.Success) return Error(result.ErrorMessage);
            return View(result.Customer);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var result = await _customerAPIService.DeleteCustomerAsync(id);
            if (!result.Success) return Error(result.ErrorMessage);
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Error(string message)
        {
            ViewBag.ErrorMessage = message;
            return View("Error");
        }
    }
}
