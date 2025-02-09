using MediPlus.Data;

namespace MediPlus.Repository
{
    public interface IBlogCategoryRepository
    {
        Task<IEnumerable<BlogCategory>> GetBlogCategoriesAsync();

        Task AddBlogCategoryAsync(BlogCategory blogCategory);
    }
}
