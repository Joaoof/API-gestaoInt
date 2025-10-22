using GestaoInt.Domain.Repositories;
using GestaoInt.Domain.Repositories.Interfaces;
using GestaoInt.Infrastructure.Infrastructure.DataAccess;
using GestaoInt.Infrastructure.Infrastructure.DataAccess.Repositories;
using GestaoInt.Infrastructure.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoInt.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
                AddDbContext(services, configuration);
                AddRepositories(services);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");

            services.AddDbContext<GestaoIntDbContext>(config => config.UseNpgsql(connectionString));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMovementsWriteOnlyRepository, MovementRepository>();
        }
    }
}
