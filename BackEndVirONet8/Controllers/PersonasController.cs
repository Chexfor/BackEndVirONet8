using AutoMapper;
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
        private readonly IMapper _mapper;

        public PersonasController(PersonaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? filtro, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var personas = await _service.ListarAsync(filtro, page, pageSize);
            var dtoList = _mapper.Map<List<PersonaDto>>(personas);
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var persona = await _service.ObtenerPorIdAsync(id);
            if (persona == null) return NotFound();

            var dto = _mapper.Map<PersonaDto>(persona);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonaDto dto)
        {
            try
            {
                var persona = _mapper.Map<Persona>(dto);
                await _service.CrearAsync(persona);

                var resultDto = _mapper.Map<PersonaDto>(persona);
                return CreatedAtAction(nameof(Get), new { id = persona.Id }, resultDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PersonaDto dto)
        {
            var persona = _mapper.Map<Persona>(dto);
            persona.Id = id;

            await _service.ActualizarAsync(persona);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/deportes")]
        public async Task<IActionResult> AsociarDeportes(int id, [FromBody] PersonaDeportesDto dto)
        {
            try
            {
                await _service.AsociarDeportesAsync(id, dto.DeportesIds);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}