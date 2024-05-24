using SaudeBemEstaApp.Domain.Entities;
using SaudeBemEstaApp.Domain.Interfaces;

namespace SaudeBemEstaApp.Domain.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public Task<IEnumerable<Prescription>> GetAllPrescriptionAsync()
        {
            return _prescriptionRepository.GetAllAsync();
        }

        public Task<Prescription> GetPrescriptionByIdAsync(int id)
        {
            return _prescriptionRepository.GetByIdAsync(id);
        }

        public Task AddPrescriptionAsync(Prescription prescription)
        {
            return _prescriptionRepository.AddAsync(prescription);
        }

        public Task UpdatePrescriptionAsync(Prescription prescription)
        {
            return _prescriptionRepository.UpdateAsync(prescription);
        }

        public Task DeletePrescriptionAsync(int id)
        {
            return _prescriptionRepository.DeleteAsync(id);
        }
    }
}
