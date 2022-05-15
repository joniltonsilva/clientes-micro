using AutoMapper;
using Clientes.Dominio.Clientes.Repositorios;
using Clientes.Dominio.Clientes.Servicos;
using Clientes.Dominio.Core.Extensoes;
using Clientes.DTO.Clientes.Request;
using Clientes.DTO.Clientes.Response;
using System.Collections.Generic;
using System.Linq;

namespace Clientes.Aplicacao.Clientes.Servicos
{
    public class RecuperarClienteAppServico : IRecuperarClienteAppServico
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IValidarClienteServico _validarClienteServico;
        public RecuperarClienteAppServico(IMapper mapper, IClienteRepositorio clienteRepositorio, IValidarClienteServico validarClienteServico)
        {
            _mapper = mapper;
            _clienteRepositorio = clienteRepositorio;
            _validarClienteServico = validarClienteServico;
        }

        public ClienteResponse RecuperarPorId(int id)
        {
            var cliente = _validarClienteServico.Validar(id);

            return _mapper.Map<ClienteResponse>(cliente);
        }

        public ClientesPaginadoResponse RecuperarPaginado(FiltrarClienteRequest request)
        {
            var query = _clienteRepositorio.IQueryable();

            if (!string.IsNullOrEmpty(request.Nome))
            {
                query = query.Where(p => p.Nome.Contains(request.Nome));
            }

            var total = query.Count();
            var resultado = query.Paginar(request.Pagina, request.QuantidadePorPagina).ToList();

            var items = _mapper.Map<List<ClienteResponse>>(resultado);

            var response = new ClientesPaginadoResponse(request.Pagina, request.QuantidadePorPagina, total, items);

            return response;
        }
    }
}
