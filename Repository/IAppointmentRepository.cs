using MediPlus.Data;

namespace MediPlus.Repository
{
    public interface IAppointmentRepository
	{
		Task<IEnumerable<Appointment>> GetAllAppointments();
		Task AddAppointment(Appointment appointment);
	}
}
