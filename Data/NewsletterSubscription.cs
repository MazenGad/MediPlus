using System.ComponentModel.DataAnnotations;
namespace MediPlus.Data
{
    public class NewsletterSubscription
    {
        [Key]
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public DateTime SubscribedAt { get; set; } = DateTime.Now;
    }
}