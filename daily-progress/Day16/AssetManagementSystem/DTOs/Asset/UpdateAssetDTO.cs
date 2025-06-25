using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.DTOs.Asset
{
    public class UpdateAssetDTO
    {
        [Required(ErrorMessage = "Asset name is required.")]
        [MaxLength(100, ErrorMessage = "Asset name cannot exceed 100 characters.")]
        public string AssetName { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "Serial number cannot exceed 100 characters.")]
        public string? SerialNumber { get; set; }

        [MaxLength(250, ErrorMessage = "Image URL is too long.")]
        public string? ImageUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ManufacturingDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }

        [Precision(18, 2)]
        public decimal? AssetValue { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [MaxLength(20)]
        public string AssetStatus { get; set; } = "Available";

        [Required(ErrorMessage = "Asset category is required.")]
        public int AssetCategoryId { get; set; }

        public int? EmployeeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? AllocationDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }
    }
}
