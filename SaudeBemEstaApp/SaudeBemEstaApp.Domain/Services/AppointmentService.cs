using SaudeBemEstaApp.Domain.Entities;
using SaudeBemEstaApp.Domain.Interfaces;

namespace SaudeBemEstaApp.Domain.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public Task<IEnumerable<Appointment>> GetAllAppointmentAsync()
        {
            return _appointmentRepository.GetAllAsync();
        }

        public Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return _appointmentRepository.GetByIdAsync(id);
        }

        public Task AddAppointmentAsync(Appointment appointment)
        {
            return _appointmentRepository.AddAsync(appointment);
        }

        public Task UpdateAppointmentAsync(Appointment appointment)
        {
            return _appointmentRepository.UpdateAsync(appointment);
        }
        public Task DeleteAppointmentAsync(int id)
        {
            return _appointmentRepository.DeleteAsync(id);
        }
    }
}
