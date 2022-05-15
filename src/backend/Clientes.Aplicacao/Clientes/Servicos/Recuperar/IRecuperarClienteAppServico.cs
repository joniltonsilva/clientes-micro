using Clientes.DTO.Clientes.Request;
using Clientes.DTO.Clientes.Response;

namespace Clientes.Aplicacao.Clientes.Servicos
{
    public interface IRecuperarClienteAppServico
    {
        ClienteResponse RecuperarPorId(int id);
        ClientesPaginadoResponse RecuperarPaginado(FiltrarClienteRequest request);
    }
}