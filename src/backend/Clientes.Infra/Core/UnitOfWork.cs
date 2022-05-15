using Clientes.Dominio.Core.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace Clientes.Infra.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IClienteDbContext _dbContext;
        public UnitOfWork(IClienteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Database.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task EndTransactionAsync(IDbContextTransaction transaction, CancellationToken cancellationToken = default)
        {
            await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task RollbackTransactionAsync(IDbContextTransaction transaction, CancellationToken cancellationToken = default)
        {
            await transaction.RollbackAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

    }
}
