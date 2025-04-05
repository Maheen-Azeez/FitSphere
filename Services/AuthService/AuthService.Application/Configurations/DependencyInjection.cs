using AuthService.Application.Services.Contracts;
using AuthService.Application.Services.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            try
            {
                
                services.AddScoped<IAuthService, AuthServiceImpl>();
                services.AddScoped<IJwtGenerator, JwtGenerator>();
                services.AddScoped<IPasswordHasher, PasswordHasher>();

                return services;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
