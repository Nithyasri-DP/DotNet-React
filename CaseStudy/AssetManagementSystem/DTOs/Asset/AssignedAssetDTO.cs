namespace AssetManagementSystem.DTOs.Asset
{
    public class AssignedAssetDTO
    {
        public string AssetName { get; set; } = string.Empty;
        public string? SerialNumber { get; set; }
        public string AssetStatus { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public DateTime? AllocationDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
