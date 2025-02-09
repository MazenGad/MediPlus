using System.ComponentModel.DataAnnotations;
namespace MediPlus.Data
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required, StringLength(100)]
        public string Author { get; set; }

		private string _titleImage;

		[Required]
		public string TitleImage
		{
			get => $"/img/{_titleImage}";
			set => _titleImage = value;
		}
        public DateTime PublishedDate { get; set; } = DateTime.Now;

        public int Views { get; set; } = 0;

        [Required]
        public int CategoryId { get; set; }
        public BlogCategory? Category { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}