using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.DTOs.ServiceRequest
{
    public class UpdateServiceRequestDTO
    {
        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; } = "Pending";

        public DateTime? ResolvedDate { get; set; }
    }
}
