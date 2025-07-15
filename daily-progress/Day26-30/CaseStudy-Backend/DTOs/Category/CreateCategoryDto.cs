using System.ComponentModel.DataAnnotations;

namespace AssetManagement.DTOs.Category
{
    public class CategoryCreateDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string CategoryName { get; set; } = string.Empty;
    }
}
