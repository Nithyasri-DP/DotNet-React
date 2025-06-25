namespace AssetManagementSystem.DTOs.Employee
{
    public class ReadEmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
