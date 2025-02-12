using Microsoft.AspNetCore.Identity;

namespace MediPlus.Data.Users
{
	public class ApplicationUser : IdentityUser
	{
		public string? Address { get; set; }
	}
}
