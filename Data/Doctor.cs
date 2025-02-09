using System.ComponentModel.DataAnnotations;
namespace MediPlus.Data
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string MedicalField { get; set; }

        [Required, StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        [Required]
        public string ProfileImageUrl { get; set; }

        public ICollection<DoctorTimetable> Timetables { get; set; } = new List<DoctorTimetable>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<EmergencyCase> EmergencyCases { get; set; } = new List<EmergencyCase>();
		public ICollection<DoctorService> DoctorServices { get; set; } = new List<DoctorService>();

	}
}