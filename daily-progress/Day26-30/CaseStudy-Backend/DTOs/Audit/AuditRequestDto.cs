using System.ComponentModel.DataAnnotations;

namespace AssetManagement.DTOs.Audit
{
    public class AuditRequestDto
    {
        [Required]
        public int AssignmentId { get; set; }

        [Required]
        public DateTime RequestedDate { get; set; }
    }
}
