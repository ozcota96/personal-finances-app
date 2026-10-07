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

        public async Task<Subcategory> CreateSubcategory(CreateSubcategoryDto subcategory)
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

        public async Task<bool> DeleteSubcategory(int subcategoryId, int userId)
        {
            var subcategory = await _subcategoriesRepository.GetSubcategoryByIdAsync(subcategoryId);
            if (subcategory == null)
            {
                return false;
            }

            subcategory.IsDeleted = true;
            // History columns
            subcategory.UpdatedAt = DateTime.UtcNow;
            subcategory.UpdatedBy = userId;

            await _subcategoriesRepository.UpdateSubcategoryAsync(subcategory);
            return true;
        }

        public async Task<bool> UpdateSubcategory(int subcategoryId, UpdateSubcategoryDto subcategoryDto, int userId)
        {
            var subcategory = await _subcategoriesRepository.GetSubcategoryByIdAsync(subcategoryId);
            if (subcategory == null)
            { 
                return false;
            }

            subcategory.Name = subcategoryDto.Name;
            subcategory.Description = subcategoryDto.Description;
            subcategory.CategoryId = subcategoryDto.CategoryId;
            // History columns
            subcategory.UpdatedAt = DateTime.UtcNow;
            subcategory.UpdatedBy = userId;

            await _subcategoriesRepository.UpdateSubcategoryAsync(subcategory);
            return true;
        }
    }
}
