using AssetManagement.DTOs.Auth;
using AssetManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AssetManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {             
                var token = await _authService.LoginAsync(request);
                var user = await _authService.GetUserByEmailAsync(request.Email);

                return Ok(new
                {
                    token,
                    email = user.Email,
                    fullName = user.FullName,
                    role = user.Role.RoleName
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "Something went wrong. Please try again later." });
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            try
            {
                var token = await _authService.ForgotPasswordAsync(request.Email);
                return Ok(new { message = "Use this token to reset password", token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            try
            {
                var message = await _authService.ResetPasswordAsync(request);
                return Ok(new { message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
