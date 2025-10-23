using core_api.Models;
using core_api.Models.Request;
using core_api.Repositories.Interfaces;
using core_api.Services.Interfaces;

namespace core_api.Services
{
    public class SubcategoriesService : ISubcategoriesService
    {
        private readonly ISubcategoriesRepository _subcategoriesRepository;

        public SubcategoriesService(ISubcategoriesRepository subcategoriesRepository)
        {
            _subcategoriesRepository = subcategoriesRepository;
        }

        public async Task<Subcategory> CreateSubcategoryAsync(CreateSubcategoryDto subcategory)
        {
            return await _subcategoriesRepository.AddSubcategoryAsync(new Subcategory
            {
                Name = subcategory.Name,
                Description = subcategory.Description,
                CategoryId = subcategory.CategoryId ?? 0,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            });
        }

        public async Task<IList<Subcategory>> GetSubcategoriesAsync()
        {
            return await _subcategoriesRepository.GetSubcategoriesAsync();
        }
    }
}
