using BackEndVirONet8.Domain.Entities;
namespace BackEndVirONet8.Infrastructure.Repositories
{
    public interface IPersonaRepository
    {
        Task<List<Persona>> GetAllAsync();
        Task<Persona?> GetByIdAsync(int id);
        Task AddAsync(Persona persona);
        Task UpdateAsync(Persona persona);
        Task DeleteAsync(int id);
        Task DeleteAllAsync(int id);
    }
}
