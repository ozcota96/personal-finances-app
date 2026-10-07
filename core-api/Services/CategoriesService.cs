using core_api.Models;
using core_api.Models.Request;
using core_api.Models.Response;
using core_api.Repositories.Interfaces;
using core_api.Services.Interfaces;

namespace core_api.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<Category> CreateCategory(CreateCategoryDto category, int userId)
        {
            return await _categoriesRepository.AddCategoryAsync(new Category
            {
                Name = category.Name,
                Description = category.Description,
                UserId = userId,
                // History columns
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = userId,
            });
        }

        public async Task<IList<Category>> GetCategories()
        {
            return await _categoriesRepository.GetCategoriesAsync();
        }

        public async Task<IList<GetCategoryDto>> GetUserCategories(int userId)
        {
            var userCategories = await _categoriesRepository.GetUserCategoriesAsync(userId);

            if (userCategories == null || !userCategories.Any())
            {
                return [];
            }

            return [.. userCategories.Select(c => new GetCategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Subcategories = [.. c.Subcategories.Select(s => new GetSubcategoryDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    CategoryId = s.CategoryId
                })]
            })];
        }

        public async Task<bool> UpdateCategory(int categoryId, CreateCategoryDto categoryDto, int userId)
        {
            var category = await _categoriesRepository.GetCategoryByIdAsync(categoryId);
            if(category is null)
            {
                return false;
            }

            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;
            // History columns
            category.UpdatedAt = DateTime.UtcNow;
            category.UpdatedBy = userId;

            await _categoriesRepository.UpdateCategoryAsync(category);
            return true;
        }

        public async Task<bool> DeleteCategory(int categoryId, int userId)
        {
            var category = await _categoriesRepository.GetCategoryByIdAsync(categoryId);
            if(category is null)
            {
                return false;
            }

            category.IsDeleted = true;
            // History columns
            category.UpdatedAt = DateTime.UtcNow;
            category.UpdatedBy = userId;

            await _categoriesRepository.UpdateCategoryAsync(category);
            return true;
        }
    }
}
