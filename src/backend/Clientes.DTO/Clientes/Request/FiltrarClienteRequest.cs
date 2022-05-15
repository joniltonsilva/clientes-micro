using Clientes.DTO.Core.Request;

namespace Clientes.DTO.Clientes.Request
{
    public class FiltrarClienteRequest : PaginadoRequest
    {
        public string Nome { get; set; }
    }
}
