namespace WebAPI_MVC.DTOs
{
    public class ProductCreationDTO
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Category { get; set; }
        public int ManufacturingCost { get; set; }
        public int SellingPrice { get; set; }
        public int Quantity { get; set; }
        public string ProductImageUrl { get; set; }
        public DateTime? ManufacturedDate { get; set; }
    }

}
