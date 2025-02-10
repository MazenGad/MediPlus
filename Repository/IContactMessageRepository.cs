using MediPlus.Data;

namespace MediPlus.Repository
{
	public interface IContactMessageRepository
    {
        Task<IEnumerable<ContactMessage>> GetContactMessagesAsync();

        Task<ContactMessage> GetContactMessagesByIdAsync(int id);

        Task AddContactMessageAsync(ContactMessage contactMessage);

        Task UpdateContactMessageAsync(ContactMessage message);

        Task DeleteContactMessageAsync(int id);

    }
}
