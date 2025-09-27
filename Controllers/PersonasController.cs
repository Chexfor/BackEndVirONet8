using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
public class PersonasController : ControllerBase
{
    private readonly PersonaService _service;

    public PersonasController(PersonaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var personas = await _service.ListarPersonasAsync();
        return Ok(personas);
    }

    // Agrega endpoints para GetById, Create, Update, Delete    
}