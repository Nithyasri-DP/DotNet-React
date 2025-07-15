using System.ComponentModel.DataAnnotations;

namespace AssetManagement.DTOs.Asset
{
    public class AssetRequestDto
    {
        [Required]
        public int AssetId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; } = 1;
    }

}
