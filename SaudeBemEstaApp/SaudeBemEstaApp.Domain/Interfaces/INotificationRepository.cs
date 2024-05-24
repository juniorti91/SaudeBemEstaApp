using SaudeBemEstaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeBemEstaApp.Domain.Interfaces
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetAllAsync();
        Task<Notification> getByIdAsync(int id);
        Task AddAsync(Notification notification);
        Task DeleteAsync(int id);
    }
}
