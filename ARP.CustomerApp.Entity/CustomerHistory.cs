using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARP.CustomerApp.Entity
{
    public class CustomerHistory
    {
        public int CustomerHistoryID { get; set; }
        public int CustomerID { get; set; }
        public DateTime DateTime { get; set; }
    }
}
