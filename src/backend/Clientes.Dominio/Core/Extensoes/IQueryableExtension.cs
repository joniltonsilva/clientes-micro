using System.Linq;

namespace Clientes.Dominio.Core.Extensoes
{
    public static class IQueryableExtension
    {
        public static IQueryable<TEntity> Paginar<TEntity>(this IQueryable<TEntity> query, int pagina, int quantidadePorPagina) where TEntity : class
        {
            return query.Skip(--pagina * quantidadePorPagina).Take(quantidadePorPagina);
        }
    }
}
