using AssetManagement.Models;

namespace AssetManagement.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
