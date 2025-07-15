using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.Models
{
    public class ServiceRequest
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [Required]
        [ForeignKey("Asset")]
        public int AssetId { get; set; }
        public Asset Asset { get; set; } = null!;

        [Required]
        public DateTime RequestDate { get; set; }

        [Required]
        [StringLength(20)]
        public string IssueType { get; set; } = string.Empty; // Malfunction, Repair

        [Required]
        [StringLength(250)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, InProgress, Completed, Rejected
    }
}
