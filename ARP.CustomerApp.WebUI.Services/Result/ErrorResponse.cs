using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARP.CustomerApp.WebUI.Services.Result
{
    /// <summary>
    /// If an API call fails an ErrorResponse is returned
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// This returns any user-facing error message
        /// </summary>
        public string Message { get; set; }
    }
}
