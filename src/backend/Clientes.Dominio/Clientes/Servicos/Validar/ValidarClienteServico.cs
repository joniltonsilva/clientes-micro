using Clientes.Dominio.Clientes.Entidades;
using Clientes.Dominio.Clientes.Repositorios;
using Clientes.Dominio.Core.Extensoes;
using Clientes.Dominio.Excecoes;

namespace Clientes.Dominio.Clientes.Servicos
{
    public class ValidarClienteServico : IValidarClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ValidarClienteServico(IClienteRepositorio clienteRepositorio)
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

        public Cliente Validar(int id)
        {
            var cliente = _clienteRepositorio.Recuperar(id);
            if (cliente.ENulo())
            {
                throw new RegistroNaoEncontradoExcecao($" para o Id: {id}");
            }

            return cliente;
        }

    }
}
