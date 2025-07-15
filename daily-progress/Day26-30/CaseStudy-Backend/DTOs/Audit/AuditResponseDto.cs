using System.ComponentModel.DataAnnotations;

namespace AssetManagement.DTOs.Audit
{
    public class AuditResponseDto
    {
        [Required]
        public int AuditId { get; set; }

        [Required]
        [RegularExpression(@"^(Verified|Rejected)$", ErrorMessage = "Status must be either 'Verified' or 'Rejected'.")]
        public string Status { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Remarks must be under 1000 characters.")]
        public string? Remarks { get; set; }
    }
}
