using AssetManagementSystem.Context;
using AssetManagementSystem.DTOs.Employee;
using AssetManagementSystem.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AssetManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class EmployeesController : ControllerBase
    {
        private readonly AssetDbContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(AssetDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET ALL EMPLOYEES
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadEmployeeDTO>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            var dtoList = _mapper.Map<List<ReadEmployeeDTO>>(employees);
            return Ok(dtoList);
        }

        // GET EMPLOYEE BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadEmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");

            var dto = _mapper.Map<ReadEmployeeDTO>(employee);
            return Ok(dto);
        }

        // CREATE EMPLOYEE or ADMIN
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(CreateEmployeeDTO dto)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            if (dto.Role == "SuperAdmin")
                return Forbid("SuperAdmin creation is restricted.");

            if ((dto.Role == "Admin") && userRole != "SuperAdmin")
                return StatusCode(403, "Only SuperAdmins can create Admins.");

            var employee = _mapper.Map<Employee>(dto);

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
        }

        // UPDATE EMPLOYEE or ADMIN
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDTO dto)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound($"Employee with ID {id} was not found.");

            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            if (employee.Role == "Admin" && userRole != "SuperAdmin")
                return Forbid("Only SuperAdmins can update Admins.");

            if (userRole == "SuperAdmin" && userId == employee.EmployeeId)
                return Forbid("SuperAdmins cannot update themselves.");

            _mapper.Map(dto, employee);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Concurrency error.");
            }

            return NoContent();
        }

        // DELETE EMPLOYEE or ADMIN
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");

            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            var userId = int.Parse(User.FindFirst("id")?.Value ?? "0");

            if ((employee.Role == "Admin" || employee.Role == "SuperAdmin") && userRole != "SuperAdmin")
                return StatusCode(403, "Only SuperAdmins can delete Admins or SuperAdmins.");

            if (employee.Role == "SuperAdmin" && employee.EmployeeId == userId)
                return StatusCode(403, "SuperAdmins cannot delete themselves.");

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
