using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pronabec.Interface.Persistence;
using Pronabec.Persistence.Context;
using Pronabec.Persistence.Repositories;

namespace Pronabec.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IInstitucionRepository, InstitucionRepository>();
            services.AddScoped<ICompromisoRepository, CompromisoRepository>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("RedisConnection");
            });

            return services;
        }
    }
}
