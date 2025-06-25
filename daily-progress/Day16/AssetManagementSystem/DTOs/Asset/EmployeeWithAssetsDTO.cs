namespace AssetManagementSystem.DTOs.Asset
{
    public class EmployeeWithAssetsDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<AssignedAssetDTO> Assets { get; set; } = new();
    }
}