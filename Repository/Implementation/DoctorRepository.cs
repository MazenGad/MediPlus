using MediPlus.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MediPlus.Repository.Implementation
{
    public class DoctorRepository : IDoctorRepository
    {
        private MediPlusContext _context;

        public DoctorRepository(MediPlusContext context)
        {
            _context = context;
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {

            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();

        }


        public Task AddDoctorTimetableAsync(DoctorTimetable timetable)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDoctorAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDoctorTimetableAsync(int timetableId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors
                .Include(d => d.Department)
                .Include(A => A.Appointments)
                .ToListAsync();

        }

        public Task<Doctor> GetDoctorByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsByDeptAsync(int departmentId)
        {
            var doctors = await _context.Doctors.Where(d => d.DepartmentId == departmentId).ToListAsync();
            return doctors;
        }

        public Task<IEnumerable<DoctorTimetable>> GetDoctorTimetablesAsync(int doctorId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDoctorAsync(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDoctorTimetableAsync(DoctorTimetable timetable)
        {
            throw new NotImplementedException();
        }
    }
}
