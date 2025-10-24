using GestaoInt.Domain.Repositories;
using GestaoInt.Domain.Repositories.Interfaces;
using GestaoInt.Domain.Repositories.User;
using GestaoInt.Domain.Security.Cryptography;
using GestaoInt.Domain.Security.Tokens;
using GestaoInt.Domain.Services.LoggedUser;
using GestaoInt.Infrastructure.Infrastructure.DataAccess;
using GestaoInt.Infrastructure.Infrastructure.DataAccess.Repositories;
using GestaoInt.Infrastructure.Security.Tokens;
using GestaoInt.Infrastructure.Services.LoggedUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoInt.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();
            services.AddScoped<ILoggedUser, LoggedUser>();

            AddDbContext(services, configuration);
            AddToken(services, configuration);
            AddRepositories(services);
        }

        private static void AddToken(IServiceCollection services, IConfiguration configuration)
        {
            var expirationMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpirationMinutes");
            var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

            services.AddScoped<IAccessTokenGenerator>(config => new AccessTokenGenerator(expirationMinutes, signingKey!));
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
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        }
    }
}
