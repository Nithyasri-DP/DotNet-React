using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.DTOs.AssetCategory
{
    public class CreateAssetCategoryDTO
    {
        [Required(ErrorMessage = "Category name is required.")]
        [MaxLength(100)]
        public string CategoryName { get; set; } = string.Empty;
    }
}
