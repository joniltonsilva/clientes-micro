using Clientes.Dominio.Clientes.Entidades;

namespace Clientes.Dominio.Clientes.Servicos
{
    public interface IValidarClienteServico
    {
        void Validar(Cliente cliente);
    }
}