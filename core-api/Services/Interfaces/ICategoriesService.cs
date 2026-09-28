using core_api.Models;
using core_api.Models.Request;
using core_api.Models.Response;

namespace core_api.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<IList<Category>> GetCategories();
        Task<IList<GetCategoryDto>> GetUserCategories(int userId);
        Task<Category> CreateCategory(CreateCategoryDto category, int userId);
        Task<bool> UpdateCategory(int categoryId, CreateCategoryDto categoryDto, int userId);
        Task<bool> DeleteCategory(int categoryId, int userId);
    }
}
