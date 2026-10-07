using core_api.Models;
using core_api.Models.Request;

namespace core_api.Services.Interfaces
{
    public interface ISubcategoriesService
    {
        Task<Subcategory> CreateSubcategory(CreateSubcategoryDto subcategory);
        Task<bool> UpdateSubcategory(int subcategoryId, UpdateSubcategoryDto subcategoryDto, int userId);
        Task<bool> DeleteSubcategory(int subcategoryId, int userId);
    }
}
