using ServiceStack;

namespace SaudeBemEstaApp.Activities.API
{
    public class ActivityConsumer : GenericConsumer
    {
        public ActivityConsumer(IService service, string hostname) : base(service, hostname)
        {
        }
    }
}
