using BackEndVirONet8.Domain.Entities;
using BackEndVirONet8.Infrastructure.Repositories;
using System.ComponentModel.DataAnnotations;

namespace BackEndVirONet8.Infrastructure.Implementations
{
    public class DeporteService
    {
        private readonly IDeporteRepository _repoDeporte;
        private readonly IPersonaRepository _repoPersona;

        public DeporteService(IDeporteRepository repoDeporte, IPersonaRepository repoPersona)
        {
            _repoDeporte = repoDeporte;
            _repoPersona = repoPersona;
        }

        public async Task<List<Deporte>> ListarAsync()
        {
            return await _repoDeporte.GetAllAsync();
        }

        public async Task<Deporte?> ObtenerPorIdAsync(int id)
        {
            return await _repoDeporte.GetByIdAsync(id);
        }

        public async Task CrearAsync(Deporte deporte)
        {
            // Validación de unicidad de nombre
            var existentes = await _repoDeporte.GetAllAsync();
            if (existentes.Any(d => d.Nombre.ToLower() == deporte.Nombre.ToLower()))
                throw new ArgumentException("Ya existe un deporte con ese nombre.");

            // Validación de DataAnnotations
            var context = new ValidationContext(deporte, null, null);
            Validator.ValidateObject(deporte, context, validateAllProperties: true);

            await _repoDeporte.AddAsync(deporte);
        }

        public async Task ActualizarAsync(Deporte deporte)
        {
            var existentes = await _repoDeporte.GetAllAsync();
            if (existentes.Any(d => d.Id != deporte.Id && d.Nombre.ToLower() == deporte.Nombre.ToLower()))
                throw new ArgumentException("Ya existe un deporte con ese nombre.");

            var context = new ValidationContext(deporte, null, null);
            Validator.ValidateObject(deporte, context, validateAllProperties: true);

            await _repoDeporte.UpdateAsync(deporte);
        }

        public async Task EliminarAsync(int id)
        {
            // Verifica si el deporte está asignado a alguna persona
            var deporte = await _repoDeporte.GetByIdAsync(id);
            if (deporte == null)
                throw new ArgumentException("Deporte no encontrado.");

            if (deporte.PersonaDeportes != null && deporte.PersonaDeportes.Any())
                throw new InvalidOperationException("No se puede eliminar el deporte porque está asignado a una o más personas.");

            await _repoDeporte.DeleteAsync(id);
        }
        public async Task EliminarAllAsync(int id)
        {
            // Verifica si el deporte existe
            var deporte = await _repoDeporte.GetByIdAsync(id);
            if (deporte == null)
                throw new ArgumentException("Deporte no encontrado.");

            // Verifica si hay personas asociadas al deporte
            if (deporte.PersonaDeportes != null && deporte.PersonaDeportes.Any())
            {
                await _repoPersona.DeleteAllAsync(id);
                
            }

            // Finalmente elimina el deporte
            await _repoDeporte.DeleteAsync(id);
        }
    }
}