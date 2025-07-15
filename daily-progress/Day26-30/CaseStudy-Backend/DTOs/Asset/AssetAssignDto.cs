namespace AssetManagement.DTOs.Asset
{
    public class AssetAssignDto
    {
        public int AssignmentId { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;

        public int AssetId { get; set; }
        public string AssetName { get; set; } = string.Empty;
        public string AssetModel { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;

        public string? ImageUrl { get; set; } 

        public int Quantity { get; set; }
        public string Status { get; set; } = string.Empty;

        public DateTime AssignedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
