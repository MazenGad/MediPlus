using MediPlus.Data;

namespace MediPlus.Repository
{
	public interface IBlogPostRepository
	{
		Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync();
		Task<IEnumerable<BlogPost>> GetRecentBlogPostsAsync();

		Task<BlogPost> GetPostByIdAsync(int id);
		Task AddBlogPostAsync(BlogPost blogPost);

        Task UpdateBlogPostAsync(BlogPost blogPost);

        Task DeleteBlogPostAsync(int id);

    }
}
