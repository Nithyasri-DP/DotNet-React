using AssetManagement.DTOs.Category;

namespace AssetManagement.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryCreateDto?> GetCategoryByIdAsync(int id);
        Task<string> CreateCategoryAsync(CategoryCreateDto dto);
        Task<string> UpdateCategoryAsync(int id, CategoryCreateDto dto);
        Task<string> DeleteCategoryAsync(int id);
    }
}
