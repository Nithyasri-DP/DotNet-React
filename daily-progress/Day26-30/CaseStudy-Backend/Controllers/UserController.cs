using AssetManagement.DTOs.User;
using AssetManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AssetManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create-employee")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto dto)
        {
            try
            {
                var result = await _userService.CreateEmployeeAsync(dto);
                return Ok(new { message = result });
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error.", detail = ex.Message });
            }
        }

        [HttpGet("employees")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _userService.GetAllEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("my-profile")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetOwnProfile()
        {
            try
            {
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
                    return Unauthorized(new { error = "Invalid or missing user token." });

                var profile = await _userService.GetOwnProfileAsync(userId);

                if (profile == null)
                    return NotFound(new { error = "Profile not found." });

                return Ok(profile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error.", detail = ex.Message });
            }
        }

        [HttpPut("update-employee")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeDto dto)
        {
            try
            {
                var updatedUser = await _userService.UpdateEmployeeAsync(dto);
                return Ok(updatedUser);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to update employee.", detail = ex.Message });
            }
        }

        [HttpGet("employee/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _userService.GetEmployeeByIdAsync(id);
                if (employee == null)
                    return NotFound(new { message = "Employee not found" });

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to fetch employee", detail = ex.Message });
            }
        }

        [HttpDelete("employee/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SoftDeleteEmployee(int id)
        {
            var result = await _userService.SoftDeleteEmployeeAsync(id);
            return Ok(new { message = result });
        }
    }
}
