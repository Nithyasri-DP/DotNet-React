using AssetManagement.DTOs.Asset;
using AssetManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsset([FromBody] AssetCreateDto assetDto)
        {
            try
            {
                var assetId = await _assetService.CreateAssetAsync(assetDto);
                if (assetId == 0)
                    return BadRequest(new { error = "Failed to create asset." });

                return Ok(new { message = "Asset created successfully", assetId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error.", detail = ex.Message });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var assets = await _assetService.GetAllAssetsAsync();
                return Ok(assets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to fetch assets.", detail = ex.Message });
            }
        }

        [HttpGet("{assetId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAssetById(int assetId)
        {
            try
            {
                var asset = await _assetService.GetAssetByIdAsync(assetId);
                if (asset == null)
                    return NotFound(new { error = "Asset not found." });

                return Ok(asset);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to fetch asset.", detail = ex.Message });
            }
        }

        [HttpPut("{assetId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsset(int assetId, [FromBody] AssetUpdateDto dto)
        {
            try
            {
                var updated = await _assetService.UpdateAssetAsync(assetId, dto);
                if (!updated)
                    return NotFound(new { error = "Asset not found." });

                return Ok(new { message = "Asset updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to update asset.", detail = ex.Message });
            }
        }

        [HttpDelete("{assetId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsset(int assetId)
        {
            try
            {
                var deleted = await _assetService.DeleteAssetAsync(assetId);
                if (!deleted)
                    return NotFound(new { error = "Asset not found." });

                return Ok(new { message = "Asset deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to delete asset.", detail = ex.Message });
            }
        }

        [HttpGet("OnlyAvailableAssets")]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult<IEnumerable<AssetAvailableDto>>> GetAvailableAssets()
        {
            try
            {
                var result = await _assetService.GetAvailableAssetsForEmployeeAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to fetch available assets.", detail = ex.Message });
            }
        }

        [HttpGet("my-assets")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetMyAssets()
        {
            try
            {
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
                    return Unauthorized(new { error = "Invalid or missing token." });

                var assets = await _assetService.GetAssignedAssetsForEmployeeAsync(userId);
                return Ok(assets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to fetch assigned assets.", detail = ex.Message });
            }
        }

        [HttpGet("employee-view/{assetId}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetAssetByIdForEmployee(int assetId)
        {
            try
            {
                var asset = await _assetService.GetAssetByIdAsync(assetId); 
                if (asset == null)
                    return NotFound(new { error = "Asset not found." });

                var dto = new
                {
                    asset.AssetId,
                    asset.AssetName,
                    asset.CategoryName,
                    asset.AssetModel,
                    asset.Quantity,
                    asset.ImageUrl,
                    asset.ManufacturingDate,
                    asset.ExpiryDate,
                    asset.Status
                };

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to fetch asset.", detail = ex.Message });
            }
        }
    }
}
