using BackEndVirONet8.Domain.Entities;
using BackEndVirONet8.Infrastructure.Repositories;

public class PersonaService
{
    private readonly IPersonaRepository _repo;

    public PersonaService(IPersonaRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Persona>> ListarPersonasAsync()
    {
        return await _repo.GetAllAsync();
    }

    // Agrega métodos para crear, actualizar, eliminar, etc.
}