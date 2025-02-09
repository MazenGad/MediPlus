﻿using System.ComponentModel.DataAnnotations;

namespace MediPlus.Data
{
	public class ContactMessage
	{
		[Key]

		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required , EmailAddress]

		public string Email { get; set; }

		[Required ]

		public string PhoneNumber { get; set; }

		[Required ]

		public string Subject { get; set; }

		[Required ]

		public string Message { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


	}
}
