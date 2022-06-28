using AFPPrueba.Models;
using AFPPrueba.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFPPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ICitaService _citasService;

        public CitasController(ICitaService citaService)
        {
            _citasService = citaService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cita>>> Get()
        {
            return await _citasService.GetCitas();
        }

   
        [HttpGet, ActionName("GetCitaByCitaId")]
        [Route("GetCitaByCitaId/{id}")]
        public async Task<ActionResult<Cita>> GetCitaByCitaId(int id)
        {
            return await _citasService.GetCitaByCitaId(id);
        }

        [HttpGet, ActionName("GetCitaByDoctorId")]
        [Route("GetCitaByDoctorId/{id}")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitaByDoctorId(int id)
        {
            return await _citasService.GetCitaByDoctorId(id);
        }

        [HttpGet, ActionName("GetCitaByClienteId")]
        [Route("GetCitaByClienteId/{id}")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitaByClienteId(int id)
        {
            return await _citasService.GetCitaByClienteId(id);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Cita cita)
        {
            var result = _citasService.AddCita(cita);
            IActionResult actionResult = null;

            if (result.Result.Succeeded)
            {
                actionResult = new OkObjectResult("Datos agregadore correctamente");
            }
            else
            {
                actionResult = new BadRequestObjectResult(result.Result.Errors);
            }
            return actionResult;
        }

        [HttpGet, ActionName("UpdateDiagnostico")]
        [Route("UpdateDiagnostico/{id}/{diagnostico}")]
        public IActionResult UpdateDiagnostico(int id, string diagnostico)
        {
            var result = _citasService.AddDiagnosticoToCita(id, diagnostico);
            IActionResult actionResult = null;

            if (result.Result.Succeeded)
            {
                actionResult = new OkObjectResult("Datos agregadore correctamente");
            }
            else
            {
                actionResult = new BadRequestObjectResult(result.Result.Errors);
            }
            return actionResult;
        }

    }
}
