using BackEndVirONet8.Domain.Entities;
using BackEndVirONet8.Infrastructure.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace BackEndVirONet8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly PersonaService _service;

        public PersonasController(PersonaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? filtro, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var personas = await _service.ListarAsync(filtro, page, pageSize);
            return Ok(personas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var persona = await _service.ObtenerPorIdAsync(id);
            if (persona == null) return NotFound();
            return Ok(persona);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Persona persona)
        {
            try
            {
                await _service.CrearAsync(persona);
                return CreatedAtAction(nameof(Get), new { id = persona.Id }, persona);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Persona persona)
        {
            if (id != persona.Id) return BadRequest();
            await _service.ActualizarAsync(persona);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarAsync(id);
            return NoContent();
        }
    }
}