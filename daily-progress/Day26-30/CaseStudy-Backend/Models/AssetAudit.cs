using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.Models
{
    public class AssetAudit
    {
        [Key]
        public int AuditId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [Required]
        [ForeignKey("Asset")]
        public int AssetId { get; set; }
        public Asset Asset { get; set; } = null!;

        [Required]
        public DateTime AuditRequestDate { get; set; }
        public DateTime? AuditResponseDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pending";

        [StringLength(250)]
        public string Remarks { get; set; } = string.Empty;
    }
}
