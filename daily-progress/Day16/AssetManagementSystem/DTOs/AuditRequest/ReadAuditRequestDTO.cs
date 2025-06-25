namespace AssetManagementSystem.DTOs.AuditRequest
{
    public class ReadAuditRequestDTO
    {
        public int AuditId { get; set; }
        public int AssetId { get; set; }
        public string? AssetName { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime RequestedDate { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public string? Remarks { get; set; }
    }
}
