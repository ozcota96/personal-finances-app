using core_api.Models;

namespace core_api.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<IList<Category>> GetCategoriesAsync();
        Task<IList<Category>> GetUserCategoriesAsync(int userId);
        Task<Category> AddCategoryAsync(Category category);
    }
}
