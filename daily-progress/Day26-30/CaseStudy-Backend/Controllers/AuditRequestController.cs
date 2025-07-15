using AssetManagement.DTOs.Audit;
using AssetManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AssetManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditRequestController : ControllerBase
    {
        private readonly IAuditRequestService _auditRequestService;

        public AuditRequestController(IAuditRequestService auditRequestService)
        {
            _auditRequestService = auditRequestService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAuditRequest([FromQuery] int assignmentId)
        {
            try
            {
                var success = await _auditRequestService.CreateAuditRequestAsync(assignmentId);
                if (!success)
                    return BadRequest("Audit request already exists.");

                return Ok("Audit request created successfully.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while creating the audit request.");
            }
        }

        [HttpGet("my")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetMyAuditRequests()
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
                var audits = await _auditRequestService.GetMyAuditRequestsAsync(userId);
                return Ok(audits);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving your audit requests.");
            }
        }

        [HttpPut("respond")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> RespondToAudit([FromBody] AuditResponseDto dto)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
                var success = await _auditRequestService.RespondToAuditAsync(dto, userId);

                if (!success)
                    return BadRequest("Invalid audit request or already responded.");

                return Ok("Audit response submitted successfully.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while responding to the audit request.");
            }
        }

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAuditRequests()
        {
            try
            {
                var audits = await _auditRequestService.GetAllAuditRequestsAsync();
                return Ok(audits);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving audit requests.");
            }
        }
    }
}
