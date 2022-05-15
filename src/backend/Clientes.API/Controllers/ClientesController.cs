using Clientes.Aplicacao.Clientes.Servicos;
using Clientes.DTO.Clientes.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Clientes.API.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {  
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(ILogger<ClientesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id, [FromServices] IRecuperarClienteAppServico appServico)
        {
            var response = appServico.RecuperarPorId(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CadastrarClienteRequest request, [FromServices] ICadastrarClienteAppServico appServico)
        {
            var response = await appServico.Cadastrar(request);

            return Created("", response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] AtualizarClienteRequest request, [FromServices] IAtualizarClienteAppServico appServico)
        {
            var response = await appServico.Atualizar(id, request);

            return Accepted(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromServices] IDeletarClienteAppServico appServico)
        {
            await appServico.Deletar(id);

            return Accepted();
        }
    }
}
