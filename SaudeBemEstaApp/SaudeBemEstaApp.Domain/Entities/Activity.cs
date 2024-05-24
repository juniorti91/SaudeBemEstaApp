namespace SaudeBemEstaApp.Domain.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string ActivityType { get; set; }
        public DateTime ActivityDate { get; set; }
        public int Duration { get; set; }
    }
}
