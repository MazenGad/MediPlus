using System.ComponentModel.DataAnnotations;
namespace MediPlus.Data
{
    public class BlogCategory
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}