using System;

namespace Clientes.Dominio.Excecoes
{
    public class JaExisteUmRegistroCadastradoExcecao : Exception
    {
        public JaExisteUmRegistroCadastradoExcecao(string registro, string dados) : base($"Já existe um {registro} com {dados}") { }
       
    }
}
