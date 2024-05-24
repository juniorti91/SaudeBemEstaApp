using Microsoft.EntityFrameworkCore;
using SaudeBemEstaApp.Domain.Entities;
using SaudeBemEstaApp.Domain.Interfaces;
using SaudeBemEstaApp.Infrastructure.Context;

namespace SaudeBemEstaApp.Infrastructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext _context;

        public ActivityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Activity activity)
        {
            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await _context.Activities.ToListAsync();
        }

        public async Task<Activity> GetByIdAsync(int id)
        {
            return await _context.Activities.FindAsync(id);
        }

        public async Task UpdateAsync(Activity activity)
        {
            _context.Entry(activity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
