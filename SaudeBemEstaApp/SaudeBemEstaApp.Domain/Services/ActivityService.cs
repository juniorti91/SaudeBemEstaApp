using SaudeBemEstaApp.Domain.Interfaces;

namespace SaudeBemEstaApp.Domain.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public Task<IEnumerable<Entities.Activity>> GetAllActivityAsync()
        {
            return _activityRepository.GetAllAsync();
        }

        public Task<Entities.Activity> GetActivityByIdAsync(int id)
        {
            return _activityRepository.GetByIdAsync(id);
        }

        public Task AddActivityAsync(Entities.Activity activity)
        {
            return _activityRepository.AddAsync(activity);
        }

        public Task UpdateActivityAsync(Entities.Activity activity)
        {
            return _activityRepository.UpdateAsync(activity);
        }

        public Task DeleteActivityAsync(int id)
        {
            return _activityRepository.DeleteAsync(id);
        }
    }
}
