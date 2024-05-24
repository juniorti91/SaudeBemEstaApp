namespace SaudeBemEstaApp.Domain.Entities
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Medication { get; set; }
        public DateTime DatePrescribed { get; set; }
        public string Dosage { get; set; }
    }
}
