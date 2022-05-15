using Clientes.Dominio.Clientes.Entidades;
using Clientes.Dominio.Clientes.Repositorios;
using Clientes.Dominio.Core.Interfaces;
using Clientes.Infra.Core.Repositorios;
using System.Linq;

namespace Clientes.Infra.Clientes.Repositorios
{
    public class ClienteRepositorio : BaseEntidadeRepositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(IClienteDbContext dbContext) : base(dbContext)
        {
        }

        public Cliente RecuperarPorNome(string nome)
        {
            return IQueryable(p => p.Nome == nome).FirstOrDefault();
        }
    }
}
