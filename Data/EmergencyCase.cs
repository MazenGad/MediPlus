using System.ComponentModel.DataAnnotations;
namespace MediPlus.Data
{
    public class EmergencyCase
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string PatientName { get; set; }

        [Required, StringLength(500)]
        public string EmergencyCondition { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        public string Status { get; set; }
    }
}