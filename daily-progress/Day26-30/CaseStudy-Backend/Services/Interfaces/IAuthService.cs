using AssetManagement.DTOs.Auth;
using AssetManagement.Models;

namespace AssetManagement.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginRequest request);
        Task<string> ForgotPasswordAsync(string email);
        Task<string> ResetPasswordAsync(ResetPasswordRequest request);
        Task<User> GetUserByEmailAsync(string email);

    }
}
