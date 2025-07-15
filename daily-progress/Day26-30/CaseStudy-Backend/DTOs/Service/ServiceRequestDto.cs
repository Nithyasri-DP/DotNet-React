using System.ComponentModel.DataAnnotations;

namespace AssetManagement.DTOs.Service
{
    public class ServiceRequestDto
    {
        [Required]
        public int AssignmentId { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Description must be under 1000 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^(Malfunction|Repair)$", ErrorMessage = "IssueType must be either 'Malfunction' or 'Repair'.")]
        public string IssueType { get; set; } = string.Empty;
    }
}
