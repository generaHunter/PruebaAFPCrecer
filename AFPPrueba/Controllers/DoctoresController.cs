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
    public class DoctoresController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctoresController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        // GET: api/<DoctoresController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> Get()
        {
            return await _doctorService.GetDoctores();
        }

        // POST api/<DoctoresController>
        [HttpPost]
        public IActionResult Post([FromBody] Doctor doctor)
        {
            var result = _doctorService.AddDoctor(doctor);
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
