namespace AssetManagement.DTOs.Asset
{
    public class AssetAvailableDto
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; } = string.Empty;
        public string AssetModel { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string? ImageUrl { get; set; }

       // public string Status => DateTime.UtcNow > ExpiryDate ? "Expired" : "Active";

    }
}
