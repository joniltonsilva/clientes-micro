using Clientes.DTO.Clientes.Response;

namespace Clientes.Aplicacao.Clientes.Servicos
{
    public interface IRecuperarClienteAppServico
    {
        ClienteResponse RecuperarPorId(int id);
    }
}