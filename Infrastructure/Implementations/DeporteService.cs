using BackEndVirONet8.Domain.Entities;
using BackEndVirONet8.Infrastructure.Repositories;
using System.ComponentModel.DataAnnotations;

namespace BackEndVirONet8.Infrastructure.Implementations
{
    public class DeporteService
    {
        private readonly IDeporteRepository _repo;

        public DeporteService(IDeporteRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Deporte>> ListarAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Deporte?> ObtenerPorIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task CrearAsync(Deporte deporte)
        {
            // Validación de unicidad de nombre
            var existentes = await _repo.GetAllAsync();
            if (existentes.Any(d => d.Nombre.ToLower() == deporte.Nombre.ToLower()))
                throw new ArgumentException("Ya existe un deporte con ese nombre.");

            // Validación de DataAnnotations
            var context = new ValidationContext(deporte, null, null);
            Validator.ValidateObject(deporte, context, validateAllProperties: true);

            await _repo.AddAsync(deporte);
        }

        public async Task ActualizarAsync(Deporte deporte)
        {
            var existentes = await _repo.GetAllAsync();
            if (existentes.Any(d => d.Id != deporte.Id && d.Nombre.ToLower() == deporte.Nombre.ToLower()))
                throw new ArgumentException("Ya existe un deporte con ese nombre.");

            var context = new ValidationContext(deporte, null, null);
            Validator.ValidateObject(deporte, context, validateAllProperties: true);

            await _repo.UpdateAsync(deporte);
        }

        public async Task EliminarAsync(int id)
        {
            // Verifica si el deporte está asignado a alguna persona
            var deporte = await _repo.GetByIdAsync(id);
            if (deporte == null)
                throw new ArgumentException("Deporte no encontrado.");

            if (deporte.PersonaDeportes != null && deporte.PersonaDeportes.Any())
                throw new InvalidOperationException("No se puede eliminar el deporte porque está asignado a una o más personas.");

            await _repo.DeleteAsync(id);
        }
    }
}