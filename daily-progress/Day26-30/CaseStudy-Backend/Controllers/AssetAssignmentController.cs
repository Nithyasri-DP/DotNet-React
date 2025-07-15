using AssetManagement.DTOs.Asset;
using AssetManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AssetManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetAssignmentController : ControllerBase
    {
        private readonly IAssetAssignmentService _assetAssignmentService;

        public AssetAssignmentController(IAssetAssignmentService assetAssignmentService)
        {
            _assetAssignmentService = assetAssignmentService;
        }

        [HttpPost("request")]
        [Authorize]
        public async Task<IActionResult> RequestAsset([FromBody] AssetRequestDto requestDto)
        {
            try
            {
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!int.TryParse(userIdString, out var userId))
                    return Unauthorized(new { error = "Invalid user ID." });

                var result = await _assetAssignmentService.RequestAssetAsync(userId, requestDto);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("assign")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignAsset([FromBody] AssetAssignInputDto dto)
        {
            try
            {
                var message = await _assetAssignmentService.AssignAssetAsync(dto);
                return Ok(new { message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to assign asset.", detail = ex.Message });
            }
        }      

        [HttpPost("request-return/{assignmentId}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> RequestReturn(int assignmentId)
        {
            try
            {
                var employeeIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!int.TryParse(employeeIdString, out var employeeId))
                    return Unauthorized(new { success = false, message = "Invalid employee ID." });

                var result = await _assetAssignmentService.RequestReturnAsync(assignmentId, employeeId);
                return Ok(new { success = true, message = result });
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Unexpected error", detail = ex.Message });
            }
        }

        [HttpGet("return-requests")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetReturnRequests()
        {
            try
            {
                var returnRequests = await _assetAssignmentService.GetAllReturnRequestsAsync();
                return Ok(returnRequests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to fetch return requests.", detail = ex.Message });
            }
        }

        [HttpPost("approve-return/{assignmentId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveReturn(int assignmentId)
        {
            try
            {
                var result = await _assetAssignmentService.ApproveReturnAsync(assignmentId);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to approve return.", detail = ex.Message });
            }
        }

        [HttpGet("PendingRequests")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPendingRequests()
        {
            try
            {
                var requests = await _assetAssignmentService.GetAllPendingRequestsAsync();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to fetch pending requests.", detail = ex.Message });
            }
        }

        [HttpPost("reject/{assignmentId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectRequest(int assignmentId)
        {
            try
            {
                var result = await _assetAssignmentService.RejectRequestAsync(assignmentId);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to reject request.", detail = ex.Message });
            }
        }

        [HttpPost("reject-return/{assignmentId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectReturn(int assignmentId)
        {
            try
            {
                var result = await _assetAssignmentService.RejectReturnRequestAsync(assignmentId);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to reject return request.", detail = ex.Message });
            }
        }

        [HttpGet("all-assigned-assets")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAssignedAssets()
        {
            try
            {
                var result = await _assetAssignmentService.GetAllAssignedAssetsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to fetch assigned assets.", detail = ex.Message });
            }
        }

        [HttpGet("rejected-requests")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetRejectedRequests()
        {
            try
            {
                var result = await _assetAssignmentService.GetAllRejectedRequestsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to fetch rejected requests.", detail = ex.Message });
            }
        }
        [HttpGet("my-assets")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetMyAssets()
        {
            try
            {
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!int.TryParse(userIdString, out var userId))
                    return Unauthorized(new { error = "Invalid user ID." });

                var result = await _assetAssignmentService.GetMyAssetsAsync(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to fetch your assets.", detail = ex.Message });
            }
        }
    }
}
