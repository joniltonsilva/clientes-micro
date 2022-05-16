using Clientes.Dominio.Clientes.Entidades;
using Clientes.Dominio.Clientes.Enumeradores;
using Clientes.Dominio.Clientes.Repositorios;
using Clientes.Dominio.Clientes.Servicos;
using Clientes.Dominio.Excecoes;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using Xunit;

namespace Clientes.TesteUnitario.Clientes
{
    public class ClienteServicoDominioTest
    {
        private readonly ValidarClienteServico sut;
        private readonly IClienteRepositorio clienteRepositorio;
        public ClienteServicoDominioTest()
        {
            clienteRepositorio = NSubstitute.Substitute.For<IClienteRepositorio>();
            sut = NSubstitute.Substitute.For<ValidarClienteServico>(clienteRepositorio);
            
        }

        [Theory()]
        [InlineData("Teste 01", ClientePorteEnum.Pequeno)]
        public void Quando_ValidarDadosClienteQueJaExisteComMesmoNome_Espero_JaExisteUmRegistroCadastradoExcecao(string nome, ClientePorteEnum porte)
        {
            var cliente = new Cliente(nome, porte);
            var clienteExistente = new Cliente("Teste 01", ClientePorteEnum.Grande);

            clienteRepositorio.RecuperarPorNome("Teste 01").Returns(clienteExistente);

            Action action = () => sut.Validar(cliente);

            action.Should().Throw<JaExisteUmRegistroCadastradoExcecao>();
        }

        [Theory()]
        [InlineData(1)]
        public void Quando_ValidarIdDeClienteQueNaoExiste_Espero_RegistroNaoEncontradoExcecao(int Id)
        {
            clienteRepositorio.Recuperar(Id).ReturnsNull();

            Action action = () => sut.Validar(Id);

            action.Should().Throw<RegistroNaoEncontradoExcecao>();
        }
    }
}
