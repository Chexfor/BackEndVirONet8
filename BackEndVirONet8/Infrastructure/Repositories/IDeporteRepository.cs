using BackEndVirONet8.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndVirONet8.Infrastructure.Repositories
{
    public interface IDeporteRepository
    {
        Task<List<Deporte>> GetAllAsync();
        Task<Deporte?> GetByIdAsync(int id);
        Task AddAsync(Deporte deporte);
        Task UpdateAsync(Deporte deporte);
        Task DeleteAsync(int id);
    }
}
