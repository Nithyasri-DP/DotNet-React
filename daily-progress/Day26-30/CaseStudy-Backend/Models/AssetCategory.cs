using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AssetManagement.Models
{
    public class AssetCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(100)]
        public string CategoryName { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
    }
}
