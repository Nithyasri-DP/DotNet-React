namespace WebAPI_MVC.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Category { get; set; }
        public int SellingPrice { get; set; }
        public int StockQuantity { get; set; }
        public string ProductImageUrl { get; set; }
    }

}
