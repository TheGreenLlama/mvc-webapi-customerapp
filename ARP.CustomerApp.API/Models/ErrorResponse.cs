namespace ARP.CustomerApp.API.Models
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
