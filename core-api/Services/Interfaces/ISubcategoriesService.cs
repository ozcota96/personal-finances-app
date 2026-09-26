using core_api.Models;
using core_api.Models.Request;

namespace core_api.Services.Interfaces
{
    public interface ISubcategoriesService
    {
        Task<IList<Subcategory>> GetSubcategories();
        Task<Subcategory> CreateSubcategory(CreateSubcategoryDto subcategory);
    }
}
