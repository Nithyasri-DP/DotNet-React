using AssetManagement.DTOs.Category;
using AssetManagement.Services.Implementations;
using AssetManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
             

        [HttpGet]
            public async Task<IActionResult> GetAllCategories()
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                var result = categories.Select(c => new CategoryDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName
                });
                return Ok(result);
            }

        [HttpGet("{id}")]
            public async Task<IActionResult> Get(int id)
            {
                try
                {
                    var category = await _categoryService.GetCategoryByIdAsync(id);
                    if (category == null)
                        return NotFound("Category not found.");
                    return Ok(category);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred while retrieving the category: {ex.Message}");
                }
            }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            try
            {
                var result = await _categoryService.CreateCategoryAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the category: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, CategoryCreateDto dto)
        {
            try
            {
                var result = await _categoryService.UpdateCategoryAsync(id, dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the category: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _categoryService.DeleteCategoryAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the category: {ex.Message}");
            }
        }
    }
}
