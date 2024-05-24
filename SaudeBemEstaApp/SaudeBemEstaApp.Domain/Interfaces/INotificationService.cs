using SaudeBemEstaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeBemEstaApp.Domain.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllNotificationAsync();
        Task<Notification> getNotificationByIdAsync(int id);
        Task AddNotificationAsync(Notification notification);
        Task DeleteNotificationAsync(int id);
    }
}
