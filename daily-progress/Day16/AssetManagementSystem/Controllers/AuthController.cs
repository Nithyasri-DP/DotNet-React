using AssetManagementSystem.Context;
using AssetManagementSystem.DTOs.Auth;
using AssetManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AssetManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AssetDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AssetDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
                
        [HttpPost("Login")]
        public IActionResult Login(LoginDTO dto)
        {
            var user = _context.Employees.FirstOrDefault(e => e.Email == dto.Email && e.Password == dto.Password);
            if (user == null) return Unauthorized("Invalid credentials");

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO dto)
        {
            var user = _context.Employees.FirstOrDefault(e => e.Email == dto.Email);
            if (user == null) return BadRequest("Email not found.");

            user.ResetPasswordToken = Guid.NewGuid().ToString();
            user.ResetTokenExpiry = DateTime.UtcNow.AddHours(1);

            await _context.SaveChangesAsync();

            // Simulate sending email: show token directly
            return Ok(new
            {
                message = "Reset token generated. Use this token in reset-password.",
                resetToken = user.ResetPasswordToken
            });
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO dto)
        {
            var user = await _context.Employees.FirstOrDefaultAsync(e =>
                e.ResetPasswordToken == dto.Token &&
                e.ResetTokenExpiry > DateTime.UtcNow);

            if (user == null)
                return BadRequest("Invalid or expired token.");

            user.Password = dto.NewPassword;
            user.ResetPasswordToken = null;
            user.ResetTokenExpiry = null;

            await _context.SaveChangesAsync();
            return Ok("Password reset successful.");
        }

        private string GenerateJwtToken(Employee user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.EmployeeId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name, user.EmployeeName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
