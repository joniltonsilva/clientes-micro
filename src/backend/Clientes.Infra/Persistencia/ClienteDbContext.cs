using Clientes.Dominio.Core.Interfaces;
using Clientes.Infra.Clientes.Mapeamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Clientes.Infra.Persistencia
{
    public class ClienteDbContext : DbContext, IClienteDbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ClienteMapeamento());
        }
    }
}
