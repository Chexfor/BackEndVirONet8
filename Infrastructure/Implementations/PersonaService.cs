using BackEndVirONet8.Domain.Entities;
using BackEndVirONet8.Infrastructure.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndVirONet8.Infrastructure.Implementations
{
    public class PersonaService
    {
        private readonly IPersonaRepository _repo;

        public PersonaService(IPersonaRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Persona>> ListarAsync(string? filtro = null, int page = 1, int pageSize = 10)
        {
            var query = _repo.GetAllAsync().Result.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
                query = query.Where(p => p.Nombre.Contains(filtro) || p.PrimerApellido.Contains(filtro) || (p.SegundoApellido != null && p.SegundoApellido.Contains(filtro)));

            return query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public async Task<Persona?> ObtenerPorIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<PersonaDto?> ObtenerDtoPorIdAsync(int id)
        {
            var persona = await _repo.GetByIdAsync(id);
            if (persona == null) return null;

            return new PersonaDto
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                PrimerApellido = persona.PrimerApellido,
                SegundoApellido = persona.SegundoApellido,
                FechaNacimiento = persona.FechaNacimiento,
                Sexo = persona.Sexo,
                Deportes = persona.PersonaDeportes
                    .Select(pd => new DeporteDto
                    {
                        Id = pd.DeporteId,
                        Nombre = pd.Deporte.Nombre
                    }).ToList()
            };
        }

        public async Task CrearAsync(Persona persona)
        {
            // Validación ejemplo: nombre requerido y longitud
            if (string.IsNullOrWhiteSpace(persona.Nombre) || persona.Nombre.Length < 2 || persona.Nombre.Length > 100)
                throw new ArgumentException("El nombre es obligatorio y debe tener entre 2 y 100 caracteres.");

            // Validación de fecha de nacimiento
            if (persona.FechaNacimiento < new DateTime(1900, 1, 1) || persona.FechaNacimiento > DateTime.Today)
                throw new ArgumentException("La fecha de nacimiento debe estar entre 1900 y hoy.");

            await _repo.AddAsync(persona);
        }

        public async Task ActualizarAsync(Persona persona)
        {
            await _repo.UpdateAsync(persona);
        }

        public async Task EliminarAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task AsociarDeportesAsync(int personaId, List<int> deportesIds)
        {
            var persona = await _repo.GetByIdAsync(personaId);
            if (persona == null)
                throw new ArgumentException("Persona no encontrada.");

            // Limpia relaciones actuales
            persona.PersonaDeportes.Clear();

            // Asocia nuevos deportes solo con los IDs
            foreach (var deporteId in deportesIds.Distinct())
            {
                persona.PersonaDeportes.Add(new PersonaDeporte
                {
                    PersonaId = personaId,
                    DeporteId = deporteId
                });
            }

            await _repo.UpdateAsync(persona);
        }
    }
}