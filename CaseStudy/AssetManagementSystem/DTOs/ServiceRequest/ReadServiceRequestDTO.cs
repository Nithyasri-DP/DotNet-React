namespace AssetManagementSystem.DTOs.ServiceRequest
{
    public class ReadServiceRequestDTO
    {
        public int RequestId { get; set; }
        public string IssueType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime RequestedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }

        public int AssetId { get; set; }
        public string? AssetName { get; set; }

        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
    }
}
