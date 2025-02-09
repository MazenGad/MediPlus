using System.ComponentModel.DataAnnotations;

namespace MediPlus.Data
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(500)]
        public string Description { get; set; }

        [Required, Range(0, 100000)]
        public decimal Price { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public  Department Department { get; set; }

		public  ICollection<DoctorService> DoctorServices { get; set; } = new List<DoctorService>();
	}
}