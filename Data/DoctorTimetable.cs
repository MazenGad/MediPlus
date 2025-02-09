using System.ComponentModel.DataAnnotations;

namespace MediPlus.Data
{
    public class DoctorTimetable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required, StringLength(10)]
        public string DayOfWeek { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }
    }
}