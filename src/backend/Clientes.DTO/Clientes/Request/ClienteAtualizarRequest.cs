using Clientes.Dominio.Clientes.Enumeradores;

namespace Clientes.DTO.Clientes.Request
{
    public class ClienteAtualizarRequest
    {
        public string Nome { get; set; }
        public ClientePorteEnum Porte { get; set; }
    }
}
