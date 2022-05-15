using Clientes.DTO.Core.Response;
using System.Collections.Generic;

namespace Clientes.DTO.Clientes.Response
{
    public class ClientesPaginadoResponse : List<ClienteResponse>
    {
        public ClientesPaginadoResponse(int pagina, int quantidadePorPagina, int total, List<ClienteResponse> items) : base(items)
        {
            Paginacao = new() { Pagina = pagina, QuantidadePorPagina = quantidadePorPagina, Total = total};
        }
        public PaginadoResponse Paginacao { get; private set; }

    }
}
