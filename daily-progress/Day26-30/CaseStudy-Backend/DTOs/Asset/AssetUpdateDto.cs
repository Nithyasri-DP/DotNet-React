using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.DTOs.Asset
{
    public class AssetUpdateDto : IValidatableObject
    {
        [StringLength(100)]
        public string? AssetName { get; set; }

        [StringLength(100)]
        public string? AssetModel { get; set; }

        public int? CategoryId { get; set; }

        public DateTime? ManufacturingDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Asset value must be greater than 0.")]
        [Precision(18, 2)]
        public decimal? AssetValue { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
        public int? Quantity { get; set; }

        public string? ImageUrl { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            if (ManufacturingDate.HasValue)
            {
                if (ManufacturingDate.Value.Year < 2000)
                {
                    yield return new ValidationResult("Manufacturing date must be after the year 2000.", new[] { nameof(ManufacturingDate) });
                }
                if (ManufacturingDate.Value > DateTime.UtcNow)
                {
                    yield return new ValidationResult("Manufacturing date cannot be in the future.", new[] { nameof(ManufacturingDate) });
                }
            }

            if (ExpiryDate.HasValue && ExpiryDate.Value <= DateTime.UtcNow)
            {
                yield return new ValidationResult("Expiry date must be a future date.", new[] { nameof(ExpiryDate) });
            }
        }
    }
}
