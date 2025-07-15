using System.ComponentModel.DataAnnotations;

public class UpdateEmployeeDto
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Phone]
    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? RoleName { get; set; }
}
