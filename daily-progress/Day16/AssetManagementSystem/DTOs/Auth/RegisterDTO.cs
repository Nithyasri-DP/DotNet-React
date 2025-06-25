using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.DTOs.Auth
{
    public class RegisterDTO
    {
        
        [Required(ErrorMessage = "Full name is required.")]
        public string EmployeeName { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^(Admin|Employee)$", ErrorMessage = "Role must be either 'Admin' or 'Employee'.")]
        public string Role { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid contact number.")]
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
    }
}


