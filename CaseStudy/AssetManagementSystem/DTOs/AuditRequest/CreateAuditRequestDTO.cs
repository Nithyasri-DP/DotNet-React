using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.DTOs.AuditRequest
{
    public class CreateAuditRequestDTO
    {
        [Required]
        public int AssetId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public string? Remarks { get; set; }
    }
}
