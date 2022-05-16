using Clientes.Aplicacao.Clientes.Servicos;
using Clientes.DTO.Clientes.Request;
using Clientes.DTO.Clientes.Response;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientesPaginadoResponse))]
        public IActionResult Get([FromQuery] FiltrarClienteRequest request, [FromServices] IRecuperarClienteAppServico appServico)
        {
            var response = appServico.RecuperarPaginado(request);

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteResponse))]
        public IActionResult Get([FromRoute] int id, [FromServices] IRecuperarClienteAppServico appServico)
        {
            var response = appServico.RecuperarPorId(id);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ClienteResponse))]
        public async Task<IActionResult> Post([FromBody] CadastrarClienteRequest request, [FromServices] ICadastrarClienteAppServico appServico)
        {
            var response = await appServico.Cadastrar(request);

            return Created("", response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(ClienteResponse))]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] AtualizarClienteRequest request, [FromServices] IAtualizarClienteAppServico appServico)
        {
            var response = await appServico.Atualizar(id, request);

            return Accepted(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(ClienteResponse))]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromServices] IDeletarClienteAppServico appServico)
        {
            await appServico.Deletar(id);

            return Accepted();
        }
    }
}
