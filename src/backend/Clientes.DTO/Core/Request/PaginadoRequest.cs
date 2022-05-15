namespace Clientes.DTO.Core.Request
{
    public abstract class PaginadoRequest
    {
        public int Pagina { get; set; } = 1;
        public int QuantidadePorPagina { get; set; } = 10;
    }
}
