using System;

namespace Clientes.Dominio.Excecoes
{
    public class AtributoNuloExcecao : Exception
    {
        public AtributoNuloExcecao(string nomeAtributo) : base($"Atributo {nomeAtributo} não pode ser nulo.") { }
       
    }
}
