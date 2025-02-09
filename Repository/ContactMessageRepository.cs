using MediPlus.Data;
using Microsoft.EntityFrameworkCore;

namespace MediPlus.Repository
{
	public class ContactMessageRepository : IContactMessageRepository
	{
		private MediPlusContext _context;

		public ContactMessageRepository(MediPlusContext context)
		{
			_context = context;
		}
		public async Task AddContactMessageAsync(ContactMessage contactMessage)
		{
			await _context.ContactMessages.AddAsync(contactMessage);
			_context.SaveChangesAsync();
		}

		public async Task<IEnumerable<ContactMessage>> GetContactMessagesAsync()
		{
			var contactMessages =await  _context.ContactMessages.ToListAsync();
			return contactMessages;
		}
	}
}
