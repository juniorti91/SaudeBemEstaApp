using SaudeBemEstaApp.Domain.Entities;
using SaudeBemEstaApp.Domain.Interfaces;

namespace SaudeBemEstaApp.Domain.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return _patientRepository.GetAllAsync();
        }

        public Task<Patient> GetPatientByIdAsync(int id)
        {
            return _patientRepository.GetByIdAsync(id);
        }

        public Task AddPatientAsync(Patient patient)
        {
            return _patientRepository.AddAsync(patient);
        }

        public Task UpdatePatientAsync(Patient patient)
        {
            return _patientRepository.UpdateAsync(patient);
        }

        public Task DeletePatientAsync(int id)
        {
            return _patientRepository.DeleteAsync(id);
        }
    }
}
