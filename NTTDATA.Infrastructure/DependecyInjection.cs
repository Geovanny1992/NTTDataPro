using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTTDATA.Application.Interfaces.Repositories;
using NTTDATA.Infrastructure.Data.Context;
using NTTDATA.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.Infrastructure
{

    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextNTTDATA>(options =>
             options.UseSqlServer(
             configuration.GetConnectionString("ISV")), ServiceLifetime.Transient);

            services.AddScoped<IPersonsRepository, PersonRepository>();
            services.AddScoped<IMovementRepository, MovementRepository>();
            services.AddScoped<IReportsRepository, ReportsRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            return services;
        }
    }
}
