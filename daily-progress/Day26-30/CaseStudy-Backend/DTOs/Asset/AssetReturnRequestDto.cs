using System.ComponentModel.DataAnnotations;

namespace AssetManagement.DTOs.Asset
{
    public class AssetReturnRequestDto
    {
        public int AssignmentId { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime AssignedDate { get; set; }
        public string ReturnStatus { get; set; } = string.Empty;
    }
}
