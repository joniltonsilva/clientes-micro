using System.Threading.Tasks;

namespace Clientes.Aplicacao.Clientes.Servicos
{
    public interface IDeletarClienteAppServico
    {
        Task Deletar(int id);
    }
}