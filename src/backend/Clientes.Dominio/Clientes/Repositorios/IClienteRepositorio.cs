using Clientes.Dominio.Clientes.Entidades;
using Clientes.Dominio.Core.Interfaces;

namespace Clientes.Dominio.Clientes.Repositorios
{
    public interface IClienteRepositorio : IBaseEntidadeRepositorio<Cliente>
    {
        Cliente RecuperarPorNome(string nome);
    }
}
