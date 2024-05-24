using SaudeBemEstaApp.Domain.Entities;

namespace SaudeBemEstaApp.Domain.Interfaces
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetAllAsync();
        Task<Activity> GetByIdAsync(int id);
        Task AddAsync(Activity activity);
        Task UpdateAsync(Activity activity);
        Task DeleteAsync(int id);
    }
}
