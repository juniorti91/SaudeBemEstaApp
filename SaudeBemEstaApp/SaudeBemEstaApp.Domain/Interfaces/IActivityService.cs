using SaudeBemEstaApp.Domain.Entities;

namespace SaudeBemEstaApp.Domain.Interfaces
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> GetAllActivityAsync();
        Task<Activity> GetActivityByIdAsync(int id);
        Task AddActivityAsync(Activity activity);
        Task UpdateActivityAsync(Activity activity);
        Task DeleteActivityAsync(int id);
    }
}
