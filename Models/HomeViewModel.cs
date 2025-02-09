using MediPlus.Data;

namespace MediPlus.Models
{
    public class HomeViewModel
    {
        public IEnumerable<OpeningHours>? OpeningHours { get; set; }
        public IEnumerable<Service>? Services { get; set; }
        public IEnumerable<Doctor>? Doctors { get; set; }
        public IEnumerable<Department>? Departments { get; set; }
        public AppointmentViewModel Appointment { get; set; }

    }

}
