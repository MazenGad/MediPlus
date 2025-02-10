using MediPlus.Data;

namespace MediPlus.Repository
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task AddAppointmentAsync(Appointment appointment);
        Task<Appointment> GetAppointmentByUserAsync(int id);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(int id);


    }
}
