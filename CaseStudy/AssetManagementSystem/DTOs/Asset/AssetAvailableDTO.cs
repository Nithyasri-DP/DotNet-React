namespace AssetManagementSystem.DTOs.Asset
{
    public class AssetAvailableDTO
    {
        public int AssetId { get; set; }

        public string AssetName { get; set; } = string.Empty;

        public string? SerialNumber { get; set; }

        public string? ImageUrl { get; set; }

        public decimal? AssetValue { get; set; }

        public string CategoryName { get; set; } = string.Empty;
    }
}
