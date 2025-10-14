using core_api.Models;
using core_api.Models.Request;

namespace core_api.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<IList<Category>> GetCategoriesAsync();
        Task<Category> CreateCategoryAsync(CreateCategoryDto category);
    }
}
