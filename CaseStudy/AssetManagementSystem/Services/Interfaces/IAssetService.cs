using AssetManagementSystem.DTOs.Asset;

namespace AssetManagementSystem.Services.Interfaces
{
    public interface IAssetService
    {
        Task<IEnumerable<AssetResponseDTO>> GetAllAssetsAsync(string? status = null, int? categoryId = null, string? userRole = null);
        Task<IEnumerable<AssetAvailableDTO>> GetAvailableAssetsAsync();
        Task<AssetResponseDTO?> GetAssetByIdAsync(int id);
        Task<AssetResponseDTO> CreateAssetAsync(CreateAssetDTO dto);
        Task<bool> UpdateAssetAsync(int id, UpdateAssetDTO dto);
        Task<bool> DeleteAssetAsync(int id);
        Task<bool> AssignAssetAsync(int assetId, int employeeId);
        Task<bool> ReturnAssetAsync(int assetId);

    }
}
