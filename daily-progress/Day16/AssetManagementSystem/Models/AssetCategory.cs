using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Models
{
    public class AssetCategory
    {
        [Key]
        public int AssetCategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        public string CategoryName { get; set; } = string.Empty;

        public ICollection<Asset>? Assets { get; set; }  // Navigation property

    }
}
