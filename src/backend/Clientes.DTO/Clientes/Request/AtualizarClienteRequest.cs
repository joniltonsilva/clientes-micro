using Clientes.Dominio.Clientes.Enumeradores;

namespace Clientes.DTO.Clientes.Request
{
    public class AtualizarClienteRequest
    {
        public string Nome { get; set; }
        public ClientePorteEnum Porte { get; set; }
    }
}
