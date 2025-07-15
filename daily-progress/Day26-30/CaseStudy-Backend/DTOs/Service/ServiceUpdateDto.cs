using System.ComponentModel.DataAnnotations;

namespace AssetManagement.DTOs.Service
{
    public class ServiceUpdateDto
    {
        [Required]
        public int ServiceRequestId { get; set; }

        [Required]
        [RegularExpression(@"^(?i)(Pending|InProgress|Completed|Rejected)$",
            ErrorMessage = "Status must be one of: Pending, Inprogress, Completed, Rejected.")]
        public string Status { get; set; } = string.Empty;
    }
}
