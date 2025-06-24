using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.DTOs.AuditRequest
{
    public class UpdateAuditRequestDTO
    {
        [Required]
        public string Status { get; set; } = "Pending";  // "Verified" or "Rejected"

        public string? Remarks { get; set; }
    }
}
