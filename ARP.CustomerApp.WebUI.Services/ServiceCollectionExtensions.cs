using ARP.CustomerApp.WebUI.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARP.CustomerApp.WebUI.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomerAppAPIServices(this IServiceCollection services) 
        { 
            services.AddTransient<ICustomerAPIService, CustomerAPIService>();
            return services;
        }
    }
}
