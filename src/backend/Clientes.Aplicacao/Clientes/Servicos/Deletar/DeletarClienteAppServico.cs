using Clientes.Dominio.Clientes.Repositorios;
using Clientes.Dominio.Clientes.Servicos;
using Clientes.Dominio.Core.Interfaces;
using System.Threading.Tasks;

namespace Clientes.Aplicacao.Clientes.Servicos
{
    public class DeletarClienteAppServico : IDeletarClienteAppServico
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IValidarClienteServico _validarClienteServico;
        public DeletarClienteAppServico(IUnitOfWork unitOfWork, IClienteRepositorio clienteRepositorio, IValidarClienteServico validarClienteServico)
        {
            _unitOfWork = unitOfWork;
            _clienteRepositorio = clienteRepositorio;
            _validarClienteServico = validarClienteServico;
        }

        public async Task Deletar(int id)
        {
            try
            {
                var cliente = _validarClienteServico.Validar(id);

                await _clienteRepositorio.Delete(id);

                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
