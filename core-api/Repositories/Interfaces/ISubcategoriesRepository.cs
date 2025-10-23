using core_api.Models;

namespace core_api.Repositories.Interfaces
{
    public interface ISubcategoriesRepository
    {
        Task<IList<Subcategory>> GetSubcategoriesAsync();
        Task<Subcategory> AddSubcategoryAsync(Subcategory subcategory);
    }
}
