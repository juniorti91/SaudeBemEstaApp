namespace SaudeBemEstaApp.Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Message { get; set; }
        public DateTime SendData { get; set; }
    }
}
