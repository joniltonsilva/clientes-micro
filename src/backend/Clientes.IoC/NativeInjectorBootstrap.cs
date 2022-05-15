using Clientes.Aplicacao.Clientes.AutoMapper;
using Clientes.Dominio.Core.Interfaces;
using Clientes.Infra.Core;
using Clientes.Infra.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clientes.IoC
{
    public static class NativeInjectorBootstrap
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<ClienteDbContext>(options => MapSqliteDbOptions(options, configuration));
            services.AddDbContext<ClienteDbContext>(options => MapSqliteDbOptions(options, configuration));

            services.AddScoped(provider => provider.GetService<ClienteDbContext>());
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(ClienteProfile));
        }

        private static void MapSqliteDbOptions(DbContextOptionsBuilder options, IConfiguration configuration)
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"), options => options.MigrationsAssembly("Clientes.Infra"));
        }

    }
}
