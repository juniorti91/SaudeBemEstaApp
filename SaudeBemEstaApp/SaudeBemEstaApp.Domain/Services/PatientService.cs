using SaudeBemEstaApp.Domain.Entities;
using SaudeBemEstaApp.Domain.Interfaces;
using System.Threading.Tasks;

namespace SaudeBemEstaApp.Domain.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly RabbitMQPublisher _publisher;  // Assumindo que você tem um publisher de eventos

        public PatientService(IPatientRepository patientRepository, RabbitMQPublisher publisher)
        {
            _patientRepository = patientRepository;
            _publisher = publisher;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _patientRepository.GetAllAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        public async Task AddPatientAsync(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
            _publisher.Publish(new { EventType = "PatientAdded", PatientId = patient.Id });
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            await _patientRepository.UpdateAsync(patient);
            _publisher.Publish(new { EventType = "PatientUpdated", PatientId = patient.Id });
        }

        public async Task DeletePatientAsync(int id)
        {
            await _patientRepository.DeleteAsync(id);
            _publisher.Publish(new { EventType = "PatientDeleted", PatientId = id });
        }
    }
}
