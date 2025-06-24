using AssetManagementSystem.DTOs.ServiceRequest;
using AssetManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly IServiceRequestService _service;

        public ServiceRequestsController(IServiceRequestService service)
        {
            _service = service;
        }

        // GET all (Admin only)
        [HttpGet]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<ActionResult<IEnumerable<ReadServiceRequestDTO>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        // GET by ID (Admin & Employee)
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin,Employee")]
        public async Task<ActionResult<ReadServiceRequestDTO>> Get(int id)
        {
            var request = await _service.GetByIdAsync(id);
            if (request == null)
                return NotFound();

            return Ok(request);
        }

        // POST (Employee)
        [HttpPost]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult<ReadServiceRequestDTO>> Create(CreateServiceRequestDTO dto)
        {
            try
            {
                var created = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(Get), new { id = created.RequestId }, created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT Status Update (Admin)
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> UpdateStatus(int id, UpdateServiceRequestDTO dto)
        {
            var success = await _service.UpdateStatusAsync(id, dto);
            if (!success)
                return NotFound($"Service request with ID {id} not found.");

            return NoContent();
        }

        // DELETE (Admin)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound($"Service request with ID {id} not found.");

            return NoContent();
        }
    }
}
