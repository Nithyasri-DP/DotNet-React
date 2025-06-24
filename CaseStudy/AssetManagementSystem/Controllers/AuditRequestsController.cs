using AssetManagementSystem.DTOs.AuditRequest;
using AssetManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditRequestsController : ControllerBase
    {
        private readonly IAuditRequestService _service;

        public AuditRequestsController(IAuditRequestService service)
        {
            _service = service;
        }

        // GET: All Audit Requests — Admin & SuperAdmin
        [HttpGet]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<ActionResult<IEnumerable<ReadAuditRequestDTO>>> GetAll()
        {
            var audits = await _service.GetAllAsync();
            return Ok(audits);
        }

        // GET: Audit Request by ID — Admin & SuperAdmin
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<ActionResult<ReadAuditRequestDTO>> Get(int id)
        {
            var audit = await _service.GetByIdAsync(id);
            if (audit == null)
                return NotFound($"Audit Request with ID {id} not found.");

            return Ok(audit);
        }

        // POST: Create Audit Request — Admin Only
        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<ActionResult<ReadAuditRequestDTO>> Create(CreateAuditRequestDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.AuditId }, created);
        }

        // PUT: Update Audit Status — Employee verifies/rejects
        [HttpPut("{id}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> UpdateStatus(int id, UpdateAuditRequestDTO dto)
        {
            var success = await _service.UpdateStatusAsync(id, dto);
            if (!success)
                return NotFound($"Audit Request with ID {id} not found or could not update.");

            return NoContent();
        }

        // DELETE: Delete Audit Request — Admin & SuperAdmin
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound($"Audit Request with ID {id} not found.");

            return NoContent();
        }
    }
}
