using AssetManagementSystem.DTOs.AssetCategory;
using AssetManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetCategoryController : ControllerBase
    {
        private readonly IAssetCategoryService _service;

        public AssetCategoryController(IAssetCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,SuperAdmin,Employee")]
        public async Task<ActionResult<IEnumerable<ReadAssetCategoryDTO>>> GetCategories()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<ActionResult<ReadAssetCategoryDTO>> GetCategory(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound("Category not found.") : Ok(result);
        }

        [HttpGet("SearchByName")]
        [Authorize(Roles = "Admin,SuperAdmin,Employee")]
        public async Task<ActionResult<IEnumerable<ReadAssetCategoryDTO>>> SearchByName([FromQuery] string? name)
        {
            return Ok(await _service.SearchByNameAsync(name));
        }

        [HttpGet("AvailableCategory")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<ActionResult<IEnumerable<CategoryWithAvailabilityDTO>>> GetAvailableStats()
        {
            return Ok(await _service.GetCategoriesWithAvailabilityAsync());
        }

        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<ActionResult<ReadAssetCategoryDTO>> CreateCategory(CreateAssetCategoryDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetCategory), new { id = created.AssetCategoryId }, created);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> UpdateCategory(int id, CreateAssetCategoryDTO dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound("Category not found.");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : BadRequest("Category not found or already assigned to assets.");
        }
    }
}
