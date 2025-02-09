using System.ComponentModel.DataAnnotations;

namespace MediPlus.Data
{
    public class OpeningHours
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Day { get; set; }

        [Required]
        public string OpenTime { get; set; }

        [Required]
        public string CloseTime { get; set; }
    }
}
