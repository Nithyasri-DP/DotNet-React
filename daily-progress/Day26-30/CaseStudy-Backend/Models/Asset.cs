using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Models
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }

        [Required(ErrorMessage = "Asset name is required")]
        [StringLength(100)]
        public string AssetName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model is required")]
        [StringLength(100)]
        public string AssetModel { get; set; } = string.Empty;

        [Required(ErrorMessage = "Manufacturing date is required")]
        public DateTime ManufacturingDate { get; set; }

        [Required(ErrorMessage = "Expiry date is required")]
        public DateTime ExpiryDate { get; set; }

        [Required(ErrorMessage = "Asset value is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Value must be greater than 0")]
        [Precision(18, 2)]
        public decimal AssetValue { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
        public int Quantity { get; set; }

        public string? ImageUrl { get; set; }

        [ForeignKey("AssetCategory")]
        public int CategoryId { get; set; }

        public AssetCategory AssetCategory { get; set; } = null!;

        public ICollection<AssetAssignment> Assignments { get; set; } = new List<AssetAssignment>();

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
    }
}
