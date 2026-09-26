using core_api.Models;
using core_api.Models.Request;

namespace core_api.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<IList<Category>> GetCategories();
        Task<IList<Category>> GetUserCategories(int userId);
        Task<Category> CreateCategory(CreateCategoryDto category);
    }
}
