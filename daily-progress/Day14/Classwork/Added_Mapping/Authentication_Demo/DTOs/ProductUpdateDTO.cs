﻿namespace Authentication_Demo.DTOs
{
    public class ProductUpdateDTO
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Category { get; set; }
        public int Manufacturing_Cost { get; set; }
        public int Selling_Price { get; set; }
        public int StockQuantity { get; set; }
        public string ProductImageUrl { get; set; }
        public DateTime? ManufacturedDate { get; set; }
        public bool IsActive { get; set; }
    }

}
