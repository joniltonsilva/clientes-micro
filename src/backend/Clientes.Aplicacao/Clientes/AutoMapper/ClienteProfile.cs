using AutoMapper;
using Clientes.Dominio.Clientes.Entidades;
using Clientes.DTO.Clientes.Request;
using Clientes.DTO.Clientes.Response;

namespace Clientes.Aplicacao.Clientes.AutoMapper
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<CadastrarClienteRequest, Cliente>();
            CreateMap<Cliente, ClienteResponse>();
        }
    }
}
