using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Models
{
    public class ServiceRequest
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        public string IssueType { get; set; } = string.Empty; 

        public string? Description { get; set; }

        [Required]
        public string Status { get; set; } = "Pending"; // "Pending", "InProgress", "Resolved"

        [DataType(DataType.DateTime)]
        public DateTime RequestedDate { get; set; } = DateTime.UtcNow;

        [DataType(DataType.DateTime)]
        public DateTime? ResolvedDate { get; set; }

        [Required]
        public int AssetId { get; set; }
        public Asset? Asset { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
