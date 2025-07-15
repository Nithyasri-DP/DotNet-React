using AssetManagement.DTOs.Asset;

namespace AssetManagement.Services.Interfaces
{
    public interface IAssetService
    {
        Task<int> CreateAssetAsync(AssetCreateDto assetDto);
        Task<IEnumerable<AssetDetailDto>> GetAllAssetsAsync();
        Task<AssetDetailDto?> GetAssetByIdAsync(int assetId);
        Task<bool> UpdateAssetAsync(int assetId, AssetUpdateDto assetDto);
        Task<bool> DeleteAssetAsync(int assetId);
        Task<IEnumerable<AssetAvailableDto>> GetAvailableAssetsForEmployeeAsync();
        Task<List<AssetAssignDto>> GetAssignedAssetsForEmployeeAsync(int userId);

    }
}
