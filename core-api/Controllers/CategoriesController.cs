using core_api.Models.Request;
using core_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace core_api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        private readonly ISubcategoriesService _subcategoriesService;

        public CategoriesController(ICategoriesService categoriesService, ISubcategoriesService subcategoriesService)
        {
            _categoriesService = categoriesService;
            _subcategoriesService = subcategoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoriesService.GetCategories();
            return categories is not null ? Ok(categories) : NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto categoryDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var category = await _categoriesService.CreateCategory(categoryDto, Convert.ToInt32(userId));
            return category is not null ? Created("api/categories/{id}", category) : Conflict();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] CreateCategoryDto categoryDto, int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var result = await _categoriesService.UpdateCategory(id, categoryDto, Convert.ToInt32(userId));
            return result ? NoContent() : NotFound();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var result = await _categoriesService.DeleteCategory(id, Convert.ToInt32(userId));
            return result ? NoContent() : NotFound();
        }
    }
}
