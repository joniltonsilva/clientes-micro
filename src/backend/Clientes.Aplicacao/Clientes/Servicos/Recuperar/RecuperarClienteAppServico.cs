using AutoMapper;
using Clientes.Dominio.Clientes.Servicos;
using Clientes.DTO.Clientes.Response;

namespace Clientes.Aplicacao.Clientes.Servicos
{
    public class RecuperarClienteAppServico : IRecuperarClienteAppServico
    {
        private readonly IMapper _mapper;
        private readonly IValidarClienteServico _validarClienteServico;
        public RecuperarClienteAppServico(IMapper mapper, IValidarClienteServico validarClienteServico)
        {
            _mapper = mapper;
            _validarClienteServico = validarClienteServico;
        }

        public ClienteResponse RecuperarPorId(int id)
        {
            var cliente = _validarClienteServico.Validar(id);

            return _mapper.Map<ClienteResponse>(cliente);
        }
    }
}
