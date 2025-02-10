using MediPlus.Data;
using Microsoft.EntityFrameworkCore;

namespace MediPlus.Repository.Implementation
{
    public class BlogCategoryRepository : IBlogCategoryRepository
    {
        MediPlusContext _context;

        public BlogCategoryRepository(MediPlusContext context)
        {
            _context = context;
        }
        public async Task AddBlogCategoryAsync(BlogCategory blogCategory)
        {
            await _context.BlogCategories.AddAsync(blogCategory);
            _context.SaveChangesAsync();

        }

        public Task DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlogCategory>> GetBlogCategoriesAsync()
        {
            var BlogCategories = await _context.BlogCategories.Include(bp => bp.BlogPosts).ToListAsync();

            return BlogCategories;
        }

        public Task<BlogCategory> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(BlogCategory category)
        {
            throw new NotImplementedException();
        }
    }
}
