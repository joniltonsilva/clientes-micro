using AutoMapper;
using Clientes.Dominio.Clientes.Entidades;
using Clientes.Dominio.Clientes.Repositorios;
using Clientes.Dominio.Clientes.Servicos;
using Clientes.Dominio.Core.Interfaces;
using Clientes.DTO.Clientes.Request;
using Clientes.DTO.Clientes.Response;
using System.Threading.Tasks;

namespace Clientes.Aplicacao.Clientes.Servicos
{
    public class AtualizarClienteAppServico : IAtualizarClienteAppServico
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IValidarClienteServico _validarClienteServico;
        public AtualizarClienteAppServico(IMapper mapper, IUnitOfWork unitOfWork, IClienteRepositorio clienteRepositorio, IValidarClienteServico validarClienteServico)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _clienteRepositorio = clienteRepositorio;
            _validarClienteServico = validarClienteServico;
        }

        public async Task<ClienteResponse> Cadastrar(CadastrarClienteRequest request)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(request);

                _validarClienteServico.Validar(cliente);

                await _clienteRepositorio.Atualizar(cliente);

                await _unitOfWork.SaveChangesAsync();

                return _mapper.Map<ClienteResponse>(cliente);
            }
            catch
            {
                throw;
            }
        }
    }
}
