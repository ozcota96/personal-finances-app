using core_api.Models;

namespace core_api.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<IList<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int categoryId);
        Task<IList<Category>> GetUserCategoriesAsync(int userId);
        Task<Category> AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Category category);
    }
}
