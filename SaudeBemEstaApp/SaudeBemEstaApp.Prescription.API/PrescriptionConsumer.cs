using ServiceStack;

namespace SaudeBemEstaApp.Prescriptions.API
{
    public class PrescriptionConsumer : GenericConsumer
    {
        public PrescriptionConsumer(IService service, string hostname) : base(service, hostname)
        {
        }
    }
}
