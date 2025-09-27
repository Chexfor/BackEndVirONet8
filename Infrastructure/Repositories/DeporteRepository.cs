using BackEndVirONet8.Domain.Entities;
using BackEndVirONet8.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BackEndVirONet8.Infrastructure.Repositories
{
    public class DeporteRepository : IDeporteRepository
    {
        private readonly AppDbContext _context;

        public DeporteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Deporte>> GetAllAsync()
        {
            return await _context.Deportes
                .Include(p => p.PersonaDeportes)
                    .ThenInclude(pd => pd.Persona)
                .ToListAsync();
        }

        public async Task<Deporte?> GetByIdAsync(int id)
        {
            return await _context.Deportes
                .Include(p => p.PersonaDeportes)
                    .ThenInclude(pd => pd.Persona)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Deporte deporte)
        {
            _context.Deportes.Add(deporte);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Deporte deporte)
        {
            _context.Deportes.Update(deporte);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deporte = await _context.Deportes.FindAsync(id);
            if (deporte != null)
            {
                _context.Deportes.Remove(deporte);
                await _context.SaveChangesAsync();
            }
        }
    }
}
