using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.DTOs.Asset
{
    public class AssetCreateDto : IValidatableObject
    {
        [Required(ErrorMessage = "Asset name is required.")]
        [StringLength(100)]
        public string AssetName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model is required.")]
        [StringLength(100)]
        public string AssetModel { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Manufacturing date is required.")]
        public DateTime ManufacturingDate { get; set; }

        [Required(ErrorMessage = "Expiry date is required.")]
        public DateTime ExpiryDate { get; set; }

        [Required(ErrorMessage = "Asset value is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Asset value must be greater than 0.")]
        [Precision(18, 2)]
        public decimal AssetValue { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        public string? ImageUrl { get; set; }

        public string Status => DateTime.UtcNow > ExpiryDate ? "Expired" : "Active";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ManufacturingDate.Year < 2000)
            {
                yield return new ValidationResult("Manufacturing date must be after the year 2000.", new[] { nameof(ManufacturingDate) });
            }

            if (ManufacturingDate > DateTime.UtcNow)
            {
                yield return new ValidationResult("Manufacturing date cannot be in the future.", new[] { nameof(ManufacturingDate) });
            }

            if (ExpiryDate <= DateTime.UtcNow)
            {
                yield return new ValidationResult("Expiry date must be a future date.", new[] { nameof(ExpiryDate) });
            }
        }
    }
}
