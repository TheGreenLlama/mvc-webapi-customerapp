using ARP.CustomerApp.Data.Interfaces;
using ARP.CustomerApp.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARP.CustomerApp.Data
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Installs the required data access services for the Customer App 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomerAppDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("CustomerDB");

            var sqlContext = new SQLConnectionContext(connectionString);
            services.AddSingleton<IConnectionContext>(sqlContext);

            services.AddTransient<ICustomerRepo, CustomerRepo>();
            services.AddTransient<ICustomerHistoryRepo, CustomerHistoryRepo>();

            return services;
        }
    }
}
