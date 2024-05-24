using SaudeBemEstaApp.Domain.Entities;
using SaudeBemEstaApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeBemEstaApp.Domain.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public Task<IEnumerable<Notification>> GetAllNotificationAsync()
        {
            return _notificationRepository.GetAllAsync();
        }
        public Task<Notification> getNotificationByIdAsync(int id)
        {
            return _notificationRepository.getByIdAsync(id);
        }

        public Task AddNotificationAsync(Notification notification)
        {
            return _notificationRepository.AddAsync(notification);
        }

        public Task DeleteNotificationAsync(int id)
        {
            return _notificationRepository.DeleteAsync(id);
        }  
    }
}
