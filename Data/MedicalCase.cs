using System.ComponentModel.DataAnnotations;
namespace MediPlus.Data
{
    public class MedicalCase
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required, MaxLength(100)]
        public string Category { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(100)]
        public string Client { get; set; }

        [MaxLength(200)]
        public string Tags { get; set; }

        public string Description { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}