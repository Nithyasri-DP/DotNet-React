using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.DTOs.ServiceRequest
{
    public class CreateServiceRequestDTO
    {
        [Required(ErrorMessage = "Issue type is required.")]
        public string IssueType { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required(ErrorMessage = "Asset ID is required.")]
        public int AssetId { get; set; }

        [Required(ErrorMessage = "Employee ID is required.")]
        public int EmployeeId { get; set; }
    }
}
