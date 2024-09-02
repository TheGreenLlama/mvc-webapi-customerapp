using ARP.CustomerApp.API.Services.Interfaces;
using ARP.CustomerApp.API.Services.UOW;
using ARP.CustomerApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARP.CustomerApp.API.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomerAppAPIServices(this IServiceCollection services, IConfiguration configuration) 
        { 
            // Add the data access layer/repos
            services.AddCustomerAppDataAccess(configuration);

            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerCreateUOW, CustomerCreateUOW>();
            services.AddTransient<ICustomerUpdateUOW, CustomerUpdateUOW>();
            services.AddTransient<ICustomerDeleteUOW, CustomerDeleteUOW>();

            return services;
        }
    }
}
