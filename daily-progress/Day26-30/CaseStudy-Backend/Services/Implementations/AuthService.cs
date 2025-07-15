using AssetManagement.Context;
using AssetManagement.DTOs.Auth;
using AssetManagement.Models;
using AssetManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BCrypt.Net; 

namespace AssetManagement.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthService(ApplicationDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        public async Task<string> LoginAsync(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                throw new BadHttpRequestException("Email and password must be provided.");

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
                throw new UnauthorizedAccessException("User not found with this email.");

            // Use BCrypt to verify the hashed password
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.Password); 
            if (!isValidPassword)
                throw new UnauthorizedAccessException("Invalid credentials. Please check your password.");

            return _tokenService.GenerateToken(user);
        }

        public async Task<string> ForgotPasswordAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || user.IsDeleted)
                throw new KeyNotFoundException("User not found.");

            user.ResetToken = Guid.NewGuid().ToString(); 
            user.ResetTokenExpiry = DateTime.UtcNow.AddMinutes(15); 
            await _context.SaveChangesAsync();
            return user.ResetToken!;
        }

        public async Task<string> ResetPasswordAsync(ResetPasswordRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u =>
                u.Email == request.Email &&
                u.ResetToken == request.Token &&
                u.ResetTokenExpiry > DateTime.UtcNow);

            if (user == null)
                throw new UnauthorizedAccessException("Invalid or expired reset token.");

            user.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword); 
            user.ResetToken = null;
            user.ResetTokenExpiry = null;

            await _context.SaveChangesAsync();
            return "Password reset successful.";
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.Role).FirstAsync(u => u.Email == email);
        }
    }
}
