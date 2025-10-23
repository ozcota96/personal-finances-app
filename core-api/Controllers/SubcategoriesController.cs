using core_api.Models.Request;
using core_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> GetSubcategories()
        {
            var subcategories = await _subcategoriesService.GetSubcategoriesAsync();
            return subcategories is not null ? Ok(subcategories) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubcategory([FromBody] CreateSubcategoryDto subcategoryDto)
        {
            var subcategory = await _subcategoriesService.CreateSubcategoryAsync(subcategoryDto);
            return subcategory is not null ? Created("api/subcategories/{id}", subcategory) : Conflict();
        }
    }
}
