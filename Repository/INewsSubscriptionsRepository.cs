using MediPlus.Data;

namespace MediPlus.Repository
{
	public interface INewsSubscriptionsRepository
	{
        Task<IEnumerable<NewsletterSubscription>> GetAllSubscriptionsAsync();

        Task<NewsletterSubscription> GetSubscriptionByIdAsync(int id);

        Task AddSubscribeAsync(NewsletterSubscription subscription);

        Task UpdateSubscriptionAsync(NewsletterSubscription subscription);

        Task DeleteSubscriptionAsync(int id);

    }
}
