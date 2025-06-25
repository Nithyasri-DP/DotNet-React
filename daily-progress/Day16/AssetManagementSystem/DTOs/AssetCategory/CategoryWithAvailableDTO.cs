namespace AssetManagementSystem.DTOs.AssetCategory
{
    public class CategoryWithAvailabilityDTO
    {
        public int AssetCategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int AvailableAssetCount { get; set; }
    }
}
