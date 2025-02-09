using System.ComponentModel.DataAnnotations;

namespace MediPlus.Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public int BlogPostId { get; set; }
        public BlogPost? BlogPost { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Content { get; set; }

		public string PostedDate { get; set; } = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
	}
}