using MediPlus.Data;

namespace MediPlus.Repository
{
	public interface IContactMessageRepository
	{
		Task AddContactMessageAsync(ContactMessage contactMessage);

		Task<IEnumerable<ContactMessage>> GetContactMessagesAsync();
	}
}
