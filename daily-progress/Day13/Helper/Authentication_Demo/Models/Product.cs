namespace Authentication_Demo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturingCost { get; set; }
        public DateTime? ManufacturedDate { get; set; }
        public int SellingPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
