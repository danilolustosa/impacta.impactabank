using ImpactaBank.API.Interface;
using ImpactaBank.API.Repository;
using ImpactaBank.API.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection DependencyConfiguration(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserService, UserService>();

            //Repositories
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
