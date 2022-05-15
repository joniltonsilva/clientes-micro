using Clientes.Dominio.Clientes.Entidades;
using Clientes.Dominio.Clientes.Repositorios;
using Clientes.Dominio.Core.Extensoes;
using Clientes.Dominio.Excecoes;
using System;

namespace Clientes.Dominio.Clientes.Servicos
{
    public class ClienteValidarServico : IClienteValidarServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteValidarServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public void Validar(Cliente cliente)
        {
            cliente.Validar();

            var clienteComMesmoNome = _clienteRepositorio.RecuperarPorNome(cliente.Nome);
            if (clienteComMesmoNome.NaoENulo() && (cliente.Id == 0 || cliente.Id != clienteComMesmoNome.Id))
            {
                throw new JaExisteUmRegistroCadastradoExcecao("Cliente", " mesmo Nome");
            }
        }

    }
}
