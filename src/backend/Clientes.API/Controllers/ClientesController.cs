﻿using Clientes.Aplicacao.Clientes.Servicos;
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
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CadastrarClienteRequest request, [FromServices] ICadastrarClienteAppServico appServico)
        {
            var response = await appServico.Cadastrar(request);

            return Created("", response);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AtualizarClienteRequest request)
        {
            return Accepted(id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Accepted(id);
        }
    }
}
