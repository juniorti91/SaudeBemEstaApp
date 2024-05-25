using ServiceStack;

namespace SaudeBemEstaApp.Notifications.API
{
    public class NotificationConsumer : GenericConsumer
    {
        public NotificationConsumer(IService service, string hostname) : base(service, hostname)
        {
        }
    }
}
