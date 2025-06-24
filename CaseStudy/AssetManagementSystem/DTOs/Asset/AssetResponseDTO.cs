namespace AssetManagementSystem.DTOs.Asset
{
    public class AssetResponseDTO
    {
        public int AssetId { get; set; }

        public string AssetName { get; set; } = string.Empty;

        public string? SerialNumber { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime? ManufacturingDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public decimal? AssetValue { get; set; }

        public string AssetStatus { get; set; } = "Available";

        public string CategoryName { get; set; } = string.Empty;

        public string? AssignedTo { get; set; }

        public DateTime? AllocationDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
