using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoliceDepartment.IoC
{
    public static class BootstrapperExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services = AddDomainDependencies(services);
            services = AddDataDependencies(services, configuration);
            return services;
        }

        private static IServiceCollection AddDomainDependencies(IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddDataDependencies(IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
