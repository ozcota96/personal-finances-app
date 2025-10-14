using core_api.Models;

namespace core_api.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<IList<Category>> GetCategoriesAsync();
        Task<Category> AddCategoryAsync(Category category);
    }
}
