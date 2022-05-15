using Clientes.Aplicacao.Clientes.AutoMapper;
using Clientes.Aplicacao.Clientes.Servicos;
using Clientes.Dominio.Clientes.Repositorios;
using Clientes.Dominio.Clientes.Servicos;
using Clientes.Dominio.Core.Interfaces;
using Clientes.Infra.Clientes.Repositorios;
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

            services.AddScoped<IClienteDbContext>(provider => provider.GetService<ClienteDbContext>());
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(ClienteProfile));

            RegistrarRepositorio(services);
            RegistrarServicoDominio(services);
            RegistrarAppServico(services);
        }

        private static void MapSqliteDbOptions(DbContextOptionsBuilder options, IConfiguration configuration)
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"), options => options.MigrationsAssembly("Clientes.Infra"));
        }

        private static void RegistrarAppServico(IServiceCollection services)
        {
            services.AddScoped<ICadastrarClienteAppServico, CadastrarClienteAppServico>();
            services.AddScoped<IAtualizarClienteAppServico, AtualizarClienteAppServico>();
            services.AddScoped<IRecuperarClienteAppServico, RecuperarClienteAppServico>();
        }

        private static void RegistrarServicoDominio(IServiceCollection services)
        {
            services.AddScoped<IValidarClienteServico, ValidarClienteServico>();
        }

        private static void RegistrarRepositorio(IServiceCollection services)
        {
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
        }
    }
}
