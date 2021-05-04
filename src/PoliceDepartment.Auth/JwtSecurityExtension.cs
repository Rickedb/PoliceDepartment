using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PoliceDepartment.Auth
{
    public static class JwtSecurityExtension
    {
        public static IServiceCollection AddJwtSecurity(this IServiceCollection services, string key)
        {
            var byteKey = Encoding.UTF8.GetBytes(key);
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(byteKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }

}
