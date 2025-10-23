using core_api.Models;
using core_api.Models.Request;

namespace core_api.Services.Interfaces
{
    public interface ISubcategoriesService
    {
        Task<IList<Subcategory>> GetSubcategoriesAsync();
        Task<Subcategory> CreateSubcategoryAsync(CreateSubcategoryDto subcategory);
    }
}
