using System;

namespace Clientes.Dominio.Excecoes
{
    public class RegistroNaoEncontradoExcecao : Exception
    {
        public RegistroNaoEncontradoExcecao(string dados) : base($"Nenhum cadastro encontrado para {dados}") { }
       
    }
}
