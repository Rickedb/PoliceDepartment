using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PoliceDepartment.Domain.Entities;
using PoliceDepartment.Domain.Validators;

namespace PoliceDepartment.IoC
{
    public static class FluentValidatorExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<int>, EntityValidator>();
            services.AddScoped<IValidator<CriminalCode>, CriminalCodeValidator>();
            services.AddScoped<IValidator<User>, UserValidator>();
            return services;
        }
    }

}
