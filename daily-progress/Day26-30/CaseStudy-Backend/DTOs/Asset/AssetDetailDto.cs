namespace AssetManagement.DTOs.Asset
{
    public class AssetDetailDto
    {        
        public int AssetId { get; set; }
        public string AssetName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string AssetModel { get; set; } = string.Empty;
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public decimal AssetValue { get; set; }
        public string? ImageUrl { get; set; }
        public string Status => DateTime.UtcNow > ExpiryDate ? "Expired" : "Active";

    }
}
