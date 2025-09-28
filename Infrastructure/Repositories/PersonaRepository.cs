using BackEndVirONet8.Domain.Entities;
using BackEndVirONet8.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BackEndVirONet8.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly AppDbContext _context;

        public PersonaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Persona>> GetAllAsync()
        {
            return await _context.Personas
                .Include(p => p.PersonaDeportes)
                    .ThenInclude(pd => pd.Deporte)
                .ToListAsync();
        }

        public async Task<Persona?> GetByIdAsync(int id)
        {
            return await _context.Personas
                .Include(p => p.PersonaDeportes)
                    .ThenInclude(pd => pd.Deporte)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Persona persona)
        {
            _context.Personas.Update(persona);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAllAsync(int id)
        {
            // Verifica si el deporte existe
            var deporte = await _context.Deportes
                .Include(d => d.PersonaDeportes)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (deporte == null)
                throw new ArgumentException("Deporte no encontrado.");

            // Elimina todas las relaciones PersonaDeporte asociadas
            if (deporte.PersonaDeportes != null && deporte.PersonaDeportes.Any())
            {
                _context.PersonaDeportes.RemoveRange(deporte.PersonaDeportes);
                await _context.SaveChangesAsync();
            }

            // Elimina el deporte
            _context.Deportes.Remove(deporte);
            await _context.SaveChangesAsync();
        }
    }
}