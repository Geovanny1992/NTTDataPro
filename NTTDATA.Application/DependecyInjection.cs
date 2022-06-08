using Microsoft.Extensions.DependencyInjection;
using NTTDATA.Application.Interfaces.Services;
using NTTDATA.Application.Service;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NTTDATA.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IMovementService, MovementService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IReporteService, ReportsService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services; 
        }
    }
}
