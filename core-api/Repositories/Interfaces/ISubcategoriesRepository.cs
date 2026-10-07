using core_api.Models;

namespace core_api.Repositories.Interfaces
{
    public interface ISubcategoriesRepository
    {
        Task<Subcategory?> GetSubcategoryByIdAsync(int subcategoryId);
        Task<Subcategory> AddSubcategoryAsync(Subcategory subcategory);
        Task UpdateSubcategoryAsync(Subcategory subcategory);
        Task DeleteSubcategoryAsync(Subcategory subcategory);
    }
}
