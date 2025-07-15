using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.Models
{
    public class AssetAssignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [Required]
        [ForeignKey("Asset")]
        public int AssetId { get; set; }
        public Asset Asset { get; set; } = null!;

        [Required]
        public DateTime AssignedDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Assigned"; // Assigned, Returned

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; } = 1;
        public bool IsReturned { get; set; } = false;

        public bool IsDeleted { get; set; } = false;

        public string ReturnStatus { get; set; } = "None"; // "Requested", "Completed"

    }
}
