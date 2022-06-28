using AFPPrueba.Models;
using AFPPrueba.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AFPPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            return await _clienteService.GetClientes();
        }

        // POST api/<ClientesController>
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            var result = _clienteService.AddCliente(cliente);
            IActionResult actionResult = null;

            if (result.Result.Succeeded)
            {
                actionResult = new OkObjectResult("Datos agregadore correctamente");
            }else
            {
                actionResult = new BadRequestObjectResult(result.Result.Errors);
            }
            return actionResult;
        }
    }
}
