using Clientes.Dominio.Excecoes;
using Clientes.Dominio.Clientes.Enumeradores;

namespace Clientes.Dominio.Clientes.Entidades
{
    public class Cliente
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual ClientePorteEnum Porte { get; protected set; }

        protected Cliente() { }

        public Cliente(string nome, ClientePorteEnum porte)
        {
            SetNome(nome);
            SetPorte(porte);
        }

        public virtual void SetId(int id)
        {
            Id = id;
        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome)) throw new AtributoNuloExcecao(nameof(Nome));

            Nome = nome;
        }

        public virtual void SetPorte(ClientePorteEnum porte)
        {
            Porte = porte;
        }

        public void Validar()
        {
            if (Nome is null) throw new AtributoNuloExcecao(nameof(Nome));
        }
    }
}
