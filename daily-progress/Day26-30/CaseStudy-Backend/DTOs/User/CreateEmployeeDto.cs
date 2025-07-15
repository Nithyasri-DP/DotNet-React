using AssetManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.DTOs.User
{
    public class CreateEmployeeDto
    {
        [Required]
        [StringLength(100)]
        public string? FullName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Contact number must be exactly 10 digits.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Contact number must be numeric.")]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(200)]
        public string? Address { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
            ErrorMessage = "Password must be at least 8 characters and include uppercase, lowercase, number, and special character.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Role name is required")]
        public string RoleName { get; set; } = string.Empty;
    }
}
