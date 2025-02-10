using MediPlus.Data;
using Microsoft.EntityFrameworkCore;

namespace MediPlus.Repository
{
	public class BlogPostRepository : IBlogPostRepository
	{
		MediPlusContext _context;

		public BlogPostRepository( MediPlusContext context )
		{
			_context = context;
		}
		public async Task AddBlogPostAsync(BlogPost blogPost)
		{
			await _context.BlogPosts.AddAsync(blogPost);
			_context.SaveChangesAsync();
		}

        public Task DeleteBlogPostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync()
		{
			var BlogPosts = await _context.BlogPosts.Include(c=>c.Category).ToListAsync();
			return BlogPosts;


		}

		public async Task<BlogPost> GetPostByIdAsync(int id)
		{
			var Post = await _context.BlogPosts.Include(c=>c.Category).FirstOrDefaultAsync(i=>i.Id == id);

			return (Post);
		}

		public async Task<IEnumerable<BlogPost>> GetRecentBlogPostsAsync()
		{
			var BlogPosts = await _context.BlogPosts.Include(c => c.Category).Include(c=>c.Comments)
				.OrderByDescending(c => c.PublishedDate.Date)
				.Take(3)
				.ToListAsync();
			return BlogPosts;
		}

        public Task UpdateBlogPostAsync(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }
    }
}
