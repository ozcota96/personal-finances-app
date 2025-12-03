using core_api.Models;
using core_api.Models.Request;
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

        public async Task<Category> CreateCategoryAsync(CreateCategoryDto category)
        {
            return await _categoriesRepository.AddCategoryAsync(new Category
            {
                Name = category.Name,
                Description = category.Description,
                UserId = category.UserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            });
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            return await _categoriesRepository.GetCategoriesAsync();
        }

        public async Task<IList<Category>> GetUserCategoriesAsync(int userId)
        {
            return await _categoriesRepository.GetUserCategoriesAsync(userId);
        }
    }
}
