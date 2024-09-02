using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARP.CustomerApp.API.Services.Interfaces;

namespace ARP.CustomerApp.API.Services
{
    /// <summary>
    /// A 'service' for delivering the 'true' date + time(!) - usually configured for regional settings etc. Since "going Azure" you can never be too cautious!
    /// </summary>
    public class DateTimeService : IDateTimeService
    {
        public DateTime CurrentDateTime
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
