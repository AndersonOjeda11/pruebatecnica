using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaApi.DTOs;
using PruebaTecnicaApi.Services.Interfaces;

namespace PruebaTecnicaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
       
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }



        [HttpGet]
        public async Task<ActionResult<PacienteListResponse>> Get()
        {
            var result =  await _pacienteService.ObtenerPacientes();

            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<PacienteListResponse>> Get(int id , [FromBody]  PacienteRequest paciente)
        {
            var result = await _pacienteService.ActualizarPaciente(id,paciente);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteListResponse>> Get(int id)
        {
            var result = await _pacienteService.ObtenerPacientePorId(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PacienteRequest paciente)
        {
            var result = await _pacienteService.CrearPaciente(paciente);

            return Ok(result);
        }
    }
}
