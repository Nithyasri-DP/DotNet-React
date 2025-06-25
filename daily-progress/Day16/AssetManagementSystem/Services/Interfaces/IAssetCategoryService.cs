using AssetManagementSystem.DTOs.AssetCategory;

namespace AssetManagementSystem.Services.Interfaces
{
    public interface IAssetCategoryService
    {
        Task<List<ReadAssetCategoryDTO>> GetAllAsync();
        Task<ReadAssetCategoryDTO?> GetByIdAsync(int id);
        Task<List<ReadAssetCategoryDTO>> SearchByNameAsync(string? name);
        Task<List<CategoryWithAvailabilityDTO>> GetCategoriesWithAvailabilityAsync();
        Task<ReadAssetCategoryDTO> CreateAsync(CreateAssetCategoryDTO dto);
        Task<bool> UpdateAsync(int id, CreateAssetCategoryDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
