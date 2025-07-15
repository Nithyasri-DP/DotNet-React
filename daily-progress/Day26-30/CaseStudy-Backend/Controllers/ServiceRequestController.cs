using AssetManagement.DTOs.Service;
using AssetManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AssetManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRequestService _serviceRequestService;

        public ServiceRequestController(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> CreateServiceRequest([FromBody] ServiceRequestDto dto)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

                var success = await _serviceRequestService.CreateServiceRequestAsync(dto, userId);
                if (!success)
                    return BadRequest("Invalid assignment or unauthorized access.");

                return Ok("Service request submitted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpGet("my")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetMyServiceRequests()
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

                var requests = await _serviceRequestService.GetMyServiceRequestsAsync(userId);
                return Ok(requests);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving your service requests.");
            }
        }

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllServiceRequests()
        {
            try
            {
                var requests = await _serviceRequestService.GetAllServiceRequestsAsync();
                return Ok(requests);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving all service requests.");
            }
        }

        [HttpPut("status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateServiceStatus([FromBody] ServiceUpdateDto dto)
        {
            try
            {
                var success = await _serviceRequestService.UpdateServiceRequestStatusAsync(dto);
                if (!success)
                    return NotFound("Service request not found.");

                return Ok("Service request status updated.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the request status.");
            }
        }
    }
}
