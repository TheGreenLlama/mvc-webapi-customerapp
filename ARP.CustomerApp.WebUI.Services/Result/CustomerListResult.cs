using ARP.CustomerApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARP.CustomerApp.WebUI.Services.Result
{
    public class CustomerListResult : ResultBase
    {
        public List<Customer> Customers { get; set; }
    }
}
