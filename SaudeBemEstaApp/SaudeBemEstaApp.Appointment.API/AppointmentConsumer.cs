using ServiceStack;

namespace SaudeBemEstaApp.Appointments.API
{
    public class AppointmentConsumer : GenericConsumer
    {
        public AppointmentConsumer(IService service, string hostname) : base(service, hostname)
        {
        }
    }
}
