using ARP.CustomerApp.Data.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARP.CustomerApp.Data.Repository
{
    public abstract class BaseRepo(ILogger logger, IConnectionContext connectionContext)
    {
        private readonly ILogger _logger = logger;
        private readonly IConnectionContext _connectionContext = connectionContext;

        /// <summary>
        /// DRY function to execute SQL in a try...catch block
        /// </summary>
        /// <typeparam name="T">The return type of the result</typeparam>
        /// <param name="sqlFunc">The SQL method to execute</param>
        /// <param name="errorMessage">Custom error message for this call</param>
        /// <returns></returns>
        public async Task<T> ExecuteSQLAsync<T>(Func<IDbConnection, Task<T>> sqlFunc, string errorMessage)
        {
            try
            {
                using (var connection = _connectionContext.Connect())
                {
                    return await sqlFunc(connection);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, errorMessage);
                throw;
            }
        }

        /// <summary>
        /// DRY function (...although I'm repeating myself here :-P) to execute SQL in a try...catch block
        /// </summary>
        /// <param name="sqlFunc">The SQL method to execute - this one without a return type</param>
        /// <param name="errorMessage">Custom error message for this call</param>
        /// <returns></returns>
        public async Task ExecuteSQLAsync(Func<IDbConnection, Task> sqlFunc, string errorMessage)
        {
            try
            {
                using (var connection = _connectionContext.Connect())
                {
                    await sqlFunc(connection);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, errorMessage);
                throw;
            }
        }

    }
}
