using MediPlus.Data;

namespace MediPlus.Repository
{
    public interface IBlogCategoryRepository
    {
        Task<IEnumerable<BlogCategory>> GetBlogCategoriesAsync();
        Task<BlogCategory> GetCategoryByIdAsync(int id);
        Task AddBlogCategoryAsync(BlogCategory blogCategory);
        Task UpdateCategoryAsync(BlogCategory category);
        Task DeleteCategoryAsync(int id);

    }
}
