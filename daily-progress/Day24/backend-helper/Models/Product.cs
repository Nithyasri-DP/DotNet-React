using System.ComponentModel.DataAnnotations;

namespace Authentication_Demo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturingCost { get; set; }
        public DateTime? ManufacturedDate { get; set; }
        public int SellingPrice { get; set; }
        public bool IsActive { get; set; } = true;
        public string ProductImageUrl { get; set; } = string.Empty;     
        public string SKU { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
