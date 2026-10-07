using core_api.Models.Request;
using core_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace core_api.Controllers
{
    [ApiController]
    [Route("api/subcategories")]
    public class SubcategoriesController : ControllerBase
    {
        private readonly ISubcategoriesService _subcategoriesService;

        public SubcategoriesController(ISubcategoriesService subcategoriesService)
        {
            _subcategoriesService = subcategoriesService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubcategory([FromBody] CreateSubcategoryDto subcategoryDto)
        {
            var subcategory = await _subcategoriesService.CreateSubcategory(subcategoryDto);
            return subcategory is not null ? Created("api/subcategories/{id}", subcategory) : Conflict();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubcategory(int id, [FromBody] UpdateSubcategoryDto subcategoryDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var result = await _subcategoriesService.UpdateSubcategory(id, subcategoryDto, Convert.ToInt32(userId));
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubcategory(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var deleted = await _subcategoriesService.DeleteSubcategory(id, Convert.ToInt32(userId));
            return deleted ? NoContent() : NotFound();
        }
    }
}
