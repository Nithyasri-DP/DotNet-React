using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Models
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }

        [Required(ErrorMessage = "Asset name is required.")]
        [MaxLength(100)]
        public string AssetName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? SerialNumber { get; set; }  // Includes asset model info too

        [MaxLength(250)]
        public string? ImageUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ManufacturingDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }

        [Precision(18, 2)]
        public decimal? AssetValue { get; set; }

        [Required(ErrorMessage = "Asset status is required.")]
        [MaxLength(20)]
        public string AssetStatus { get; set; } = "Available";  // "Available", "Assigned", "Returned"

        public int AssetCategoryId { get; set; }
        public int? EmployeeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? AllocationDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public AssetCategory? AssetCategory { get; set; }
        public Employee? Employee { get; set; }
    }
}
