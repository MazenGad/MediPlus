using MediPlus.Data;
using Microsoft.EntityFrameworkCore;

namespace MediPlus.Repository
{
    public class BlogCategoryRepository : IBlogCategoryRepository
    {
        MediPlusContext _context;

        public BlogCategoryRepository( MediPlusContext context )
        {
                _context = context;
        }
        public async Task AddBlogCategoryAsync(BlogCategory blogCategory)
        {
            await _context.BlogCategories.AddAsync( blogCategory );
            _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<BlogCategory>> GetBlogCategoriesAsync()
        {
            var BlogCategories = await _context.BlogCategories.Include(bp=>bp.BlogPosts).ToListAsync();

            return BlogCategories;
        }
    }
}
