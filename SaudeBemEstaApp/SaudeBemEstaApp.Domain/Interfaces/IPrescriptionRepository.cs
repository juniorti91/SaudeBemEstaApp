using SaudeBemEstaApp.Domain.Entities;

namespace SaudeBemEstaApp.Domain.Interfaces
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> GetAllAsync();
        Task<Prescription> GetByIdAsync(int id);
        Task AddAsync(Prescription prescription);
        Task UpdateAsync(Prescription prescription);
        Task DeleteAsync(int id);
    }
}
