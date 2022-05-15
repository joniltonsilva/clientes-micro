using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Clientes.Dominio.Core.Interfaces
{
    public interface IClienteDbContext
    {
        DatabaseFacade Database { get;}
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
