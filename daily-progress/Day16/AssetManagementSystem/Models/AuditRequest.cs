using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Models
{
    public class AuditRequest
    {
        [Key]
        public int AuditId { get; set; }

        [Required]
        public int AssetId { get; set; }
        public Asset? Asset { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";  // "Pending", "Verified", "Rejected"

        [DataType(DataType.DateTime)]
        public DateTime RequestedDate { get; set; } = DateTime.UtcNow;

        [DataType(DataType.DateTime)]
        public DateTime? VerifiedDate { get; set; }

        public string? Remarks { get; set; }
    }
}
