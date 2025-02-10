using MediPlus.Data;

namespace MediPlus.Repository
{
	public class NewsSubscriptionsRepository : INewsSubscriptionsRepository
	{
		MediPlusContext _context;

		public NewsSubscriptionsRepository(MediPlusContext context)
		{
			_context = context;
		}

		public async Task AddSubscribeAsync(NewsletterSubscription subscription)
		{
			await _context.NewsletterSubscriptions.AddAsync(subscription);
			_context.SaveChangesAsync();
		}

        public Task DeleteSubscriptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NewsletterSubscription>> GetAllSubscriptionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<NewsletterSubscription> GetSubscriptionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSubscriptionAsync(NewsletterSubscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
