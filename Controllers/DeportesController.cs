using AutoMapper;
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
        private readonly IMapper _mapper;

        public DeportesController(DeporteService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var deportes = await _service.ListarAsync();
            var dtoList = _mapper.Map<List<DeporteDto>>(deportes);
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var deporte = await _service.ObtenerPorIdAsync(id);
            if (deporte == null) return NotFound();

            var dto = _mapper.Map<DeporteDto>(deporte);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DeporteDto dto)
        {
            try
            {
                var deporte = _mapper.Map<Deporte>(dto);
                await _service.CrearAsync(deporte);

                var resultDto = _mapper.Map<DeporteDto>(deporte);
                return CreatedAtAction(nameof(Get), new { id = deporte.Id }, resultDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DeporteDto dto)
        {
            if (id != dto.Id) return BadRequest();

            try
            {
                var deporte = _mapper.Map<Deporte>(dto);
                await _service.ActualizarAsync(deporte);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAll(int id)
        {
            try
            {
                await _service.EliminarAllAsync(id);
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