using BackEndVirONet8.Domain.Entities;
using BackEndVirONet8.Infrastructure.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace BackEndVirONet8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeportesController : ControllerBase
    {
        private readonly DeporteService _service;

        public DeportesController(DeporteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var deportes = await _service.ListarAsync();
            return Ok(deportes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var deporte = await _service.ObtenerPorIdAsync(id);
            if (deporte == null) return NotFound();
            return Ok(deporte);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Deporte deporte)
        {
            try
            {
                await _service.CrearAsync(deporte);
                return CreatedAtAction(nameof(Get), new { id = deporte.Id }, deporte);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Deporte deporte)
        {
            if (id != deporte.Id) return BadRequest();
            try
            {
                await _service.ActualizarAsync(deporte);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.EliminarAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
}