using System.ComponentModel.DataAnnotations;

namespace MediPlus.Data
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(500)]
        public string Description { get; set; }


        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
        public ICollection<Service> Services { get; set; } = new List<Service>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}