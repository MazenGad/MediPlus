using MediPlus.Data;

namespace MediPlus.Models
{
    public class AppointmentViewModel
    {
        public Appointment Appointment { get; set; } 
        public IEnumerable<Department>? Departments { get; set; } 
        public IEnumerable<Doctor>? Doctors { get; set; } 
    }
}
