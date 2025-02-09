using System.ComponentModel.DataAnnotations;

namespace MediPlus.Data
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string PatientName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public string Message { get; set; }

        [Required]
        public string? Status { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}