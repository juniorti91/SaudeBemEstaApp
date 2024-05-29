namespace SaudeBemEstaApp.Patients.API
{
    public class PatientConsumer : GenericConsumer
    {
        public PatientConsumer(IService service, string hostname) : base(service, hostname)
        {
        }
    }
}
