using Clientes.DTO.Clientes.Request;
using Clientes.DTO.Clientes.Response;
using System.Threading.Tasks;

namespace Clientes.Aplicacao.Clientes.Servicos
{
    public interface IAtualizarClienteAppServico
    {
        Task<ClienteResponse> Atualizar(int id, AtualizarClienteRequest request);
    }
}