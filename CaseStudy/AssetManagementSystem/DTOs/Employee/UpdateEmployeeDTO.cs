using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.DTOs.Employee
{
    public class UpdateEmployeeDTO
    {
        [Required(ErrorMessage = "Full name is required.")]
        public string EmployeeName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        public string? ContactNumber { get; set; }

        public string? Address { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        [RegularExpression("^(Admin|Employee|SuperAdmin)$", ErrorMessage = "Invalid role.")]
        public string Role { get; set; } = string.Empty;


    }
}
