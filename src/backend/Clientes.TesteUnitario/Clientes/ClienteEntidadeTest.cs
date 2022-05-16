using Clientes.Dominio.Clientes.Entidades;
using Xunit;
using Moq;
using FluentAssertions;
using System;
using Clientes.Dominio.Clientes.Enumeradores;
using Clientes.Dominio.Excecoes;

namespace Clientes.TesteUnitario.Clientes
{
    public class ClienteEntidadeTest
    {

        [Theory()]
        [InlineData("Teste 01", ClientePorteEnum.Pequeno)]
        [InlineData("Teste 02", ClientePorteEnum.Medio)]
        [InlineData("Teste 03", ClientePorteEnum.Grande)]
        public void Quando_DadosValidos_Espero_ObjetoIntegro(string nome, ClientePorteEnum porte)
        {
            var cliente = new Cliente(nome, porte);

            cliente.Nome.Should().NotBeNull();

            Action action = () => cliente.Validar();

            action.Should().NotThrow();
        }

        [Theory()]
        [InlineData("", ClientePorteEnum.Pequeno)]
        [InlineData(null, ClientePorteEnum.Grande)]
        public void Quando_DadosInvalidos_Espero_AtributoNuloExcecao(string nome, ClientePorteEnum porte)
        {
            Action action = () => new Cliente(nome, porte);

            action.Should().Throw<AtributoNuloExcecao>();
        }
    }
}
