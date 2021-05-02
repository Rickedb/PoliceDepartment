using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoliceDepartment.IoC
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "PoliceDepartment", Version = "v1" });

            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerUIConfig(this IApplicationBuilder application)
        {
            application.UseSwagger();
            application.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
            });

            return application;
        }
    }

}
