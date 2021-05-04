using Microsoft.AspNet.OData.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PoliceDepartment.Auth;
using PoliceDepartment.Auth.Authentication;
using PoliceDepartment.Auth.Cryptography;
using PoliceDepartment.Data.Contexts;
using PoliceDepartment.Data.Repositories;
using PoliceDepartment.Domain.Entities;
using PoliceDepartment.Domain.Interfaces.Repositories;
using PoliceDepartment.Domain.Interfaces.Services;
using PoliceDepartment.Domain.Services;

namespace PoliceDepartment.IoC
{
    public static class BootstrapperExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services = services.AddDomainDependencies()
                                .AddDataDependencies(configuration)
                                .AddAuthDependencies(configuration);
            return services;
        }

        private static IServiceCollection AddAuthDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var authOptions = configuration.GetSection("Auth:Authentication").Get<AuthenticationOptions>();
            var cryptographyOptions = configuration.GetSection("Auth:Cryptography").Get<CryptographyOptions>();
            return services.AddScoped(provider => authOptions)
                            .AddScoped(provider => cryptographyOptions)
                            .AddJwtSecurity(authOptions.Secret);
        }

        private static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            return services.AddTransient<IAuthenticationService, AuthenticationService>()
                            .AddTransient<ICryptographyService, CryptographyService>()
                            .AddTransient<IQueryableDatabaseService<CriminalCode>, CriminalCodeService>()
                            .AddTransient<IDatabaseService<User>, UserService>();
        }

        private static IServiceCollection AddDataDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserRepository, UserRepository>()
                    .AddTransient<IQueryableRepository<CriminalCode>, CriminalCodeRepository>()
                    .AddDbContext<PoliceDepartmentContext>(options => options.UseNpgsql(configuration.GetConnectionString(nameof(PoliceDepartmentContext))))
                    .AddOData();
            return services;
        }


    }
}
