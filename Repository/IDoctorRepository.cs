using System.Collections.Generic;
using System.Threading.Tasks;
using MediPlus.Data;

namespace MediPlus.Repository
{
    public interface IDoctorRepository
    {
		Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
		Task<IEnumerable<Doctor>> GetDoctorsByDeptAsync(int departmentId);
		Task<Doctor> GetDoctorByIdAsync(int id);
		Task AddDoctorAsync(Doctor doctor);
		Task UpdateDoctorAsync(Doctor doctor);
		Task DeleteDoctorAsync(int id);

		Task<IEnumerable<DoctorTimetable>> GetDoctorTimetablesAsync(int doctorId);
		Task AddDoctorTimetableAsync(DoctorTimetable timetable);
		Task UpdateDoctorTimetableAsync(DoctorTimetable timetable);
		Task<bool> DeleteDoctorTimetableAsync(int timetableId);
	}
}
