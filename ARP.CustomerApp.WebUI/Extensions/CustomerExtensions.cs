using ARP.CustomerApp.Entity;

namespace ARP.CustomerApp.WebUI.Extensions
{
    public static class CustomerExtensions
    {
        public static string FormatAddress(this Customer customer)
        {
            string[] addressElements = new[] { customer.Address1, customer.Address2, customer.Address3, customer.Town, customer.County };
            return String.Join(", ", addressElements.Where(s => !String.IsNullOrWhiteSpace(s)));
        }
    }
}
