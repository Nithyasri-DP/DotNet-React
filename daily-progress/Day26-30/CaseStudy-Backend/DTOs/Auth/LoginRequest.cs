using System.ComponentModel.DataAnnotations;

namespace AssetManagement.DTOs.Auth
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty;
    }
}
