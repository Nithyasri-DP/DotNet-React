using AssetManagementSystem.DTOs.Asset;
using AssetManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AssetManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetsController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        // EMPLOYEE + ADMIN: Get all available assets
        [HttpGet("AvailableAssets")]
        [Authorize(Roles = "Employee,Admin,SuperAdmin")]
        public async Task<ActionResult<IEnumerable<AssetAvailableDTO>>> GetAvailableAssets()
        {
            var assets = await _assetService.GetAvailableAssetsAsync();
            return Ok(assets);
        }

        // GET BY ID (Admin/SuperAdmin only)
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<ActionResult<AssetResponseDTO>> GetAsset(int id)
        {
            var asset = await _assetService.GetAssetByIdAsync(id);
            if (asset == null)
                return NotFound($"Asset with ID {id} not found.");

            return Ok(asset);
        }

        // FILTER (Status + Category)
        [HttpGet("AssetByFilter")]
        [Authorize(Roles = "Admin,SuperAdmin,Employee")]
        public async Task<ActionResult<IEnumerable<AssetResponseDTO>>> GetAssets(
            [FromQuery] string? status,
            [FromQuery] int? categoryId)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value ?? "Employee";
            var assets = await _assetService.GetAllAssetsAsync(status, categoryId, userRole);
            return Ok(assets);
        }

        // CREATE (Admin/SuperAdmin)
        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<ActionResult<AssetResponseDTO>> CreateAsset(CreateAssetDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdAsset = await _assetService.CreateAssetAsync(dto);
            return CreatedAtAction(nameof(GetAsset), new { id = createdAsset.AssetId }, createdAsset);
        }

        // UPDATE (Admin/SuperAdmin)
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> UpdateAsset(int id, UpdateAssetDTO dto)
        {
            var updated = await _assetService.UpdateAssetAsync(id, dto);
            if (!updated)
                return NotFound($"Asset with ID {id} not found.");

            return NoContent();
        }

        // Assign Asset to Employee by AssetID
        [HttpPut("AssignAsset/{assetId}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> AssignAsset(int assetId, AssignAssetDTO dto)
        {
            var result = await _assetService.AssignAssetAsync(assetId, dto.EmployeeId);
            if (!result)
                return BadRequest("Asset or Employee not found, or Asset is already assigned.");

            return Ok("Asset successfully assigned.");
        }

        // Asset return is marked by Admin
        [HttpPut("MarkReturn{id}/")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> ReturnAsset(int id)
        {
            var success = await _assetService.ReturnAssetAsync(id);
            if (!success)
                return NotFound($"Asset with ID {id} not found or not assigned.");

            return Ok($"Asset with ID {id} marked as returned.");
        }

        // DELETE (Admin/SuperAdmin)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            var deleted = await _assetService.DeleteAssetAsync(id);
            if (!deleted)
                return NotFound($"Asset with ID {id} not found.");

            return NoContent();
        }
    }
}
