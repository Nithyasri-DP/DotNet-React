using System;
using System.Collections.Generic;
using System.Linq;

namespace VSDotnetClass.Dayfour
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ? Name { get; set; }
        public string ? Description { get; set; }
        public int Price { get; set; }
        public string ? Category { get; set; }

        static List<Product> products = new List<Product>()
        {
            new Product() {ProductId=1, Name="Mouse", Description="Wireless", Price=1300, Category="Electronics"},
            new Product() {ProductId=2, Name="Keyboard", Description="Wireless", Price=3220, Category="Electronics"},
            new Product() {ProductId=3, Name="Laptop", Description="HD and Touch", Price=87000, Category="Electronics"},
            new Product() {ProductId=4, Name="Cooling Pad", Description="test", Price=2000, Category="Electronics"},
            new Product() {ProductId=5, Name="Monitor", Description="LED", Price=6000, Category="Electronics"},
            new Product() {ProductId=6, Name="Projector", Description="Wired", Price=1700, Category="Electronics"},
            new Product() {ProductId=7, Name="Pencil", Description="Color pencil", Price=170, Category="Stationary"},
            new Product() {ProductId=8, Name="Scale", Description="long size", Price=100, Category="Stationary"}
        };

        // Method used in Supplier.cs
        public static List<Product> GetAllProducts()
        {
            return products;
        }

        public static void RunProduct()
        {
            Console.WriteLine("\nProducts with price >= 5000");
            var productsPriceMoreThan5000 = products.Where(p => p.Price >= 5000);
            foreach (var product in productsPriceMoreThan5000)
            {
                Console.WriteLine($"{product.ProductId}\t{product.Name}\t{product.Price}");
            }

            // ORDER BY Name Descending - Query Syntax
            Console.WriteLine("\nOrdered by Name Descending (Query Syntax)");
            var orderbyProductName = from p in products
                                     orderby p.Name descending
                                     select p;
            foreach (var product in orderbyProductName)
            {
                Console.WriteLine($"{product.Name}");
            }

            // ORDER BY Name Descending - Method Syntax
            Console.WriteLine("\nOrdered by Name Descending (Method Syntax)");
            var orderbyProductName1 = products.OrderByDescending(p => p.Name);
            foreach (var product in orderbyProductName1)
            {
                Console.WriteLine($"{product.Name}");
            }

            // ORDER BY Name Ascending, Price Descending - Query Syntax
            Console.WriteLine("\nOrdered by Name Ascending, then Price Descending (Query Syntax)");
            var orderbyPriceName = from p in products
                                   orderby p.Name ascending, p.Price descending
                                   select new { p.Name, p.Price };
            foreach (var product in orderbyPriceName)
            {
                Console.WriteLine($"{product.Name}\t{product.Price}");
            }

            // ORDER BY Name Ascending, Price Descending - Method Syntax
            Console.WriteLine("\nOrdered by Name Ascending, then Price Descending (Method Syntax)");
            var orderbyPriceName1 = products
                .OrderBy(p => p.Name)
                .ThenByDescending(p => p.Price);
            foreach (var product in orderbyPriceName1)
            {
                Console.WriteLine($"{product.Name}\t{product.Price}");
            }

            // Example for Group By - Query Syntax
            Console.WriteLine("\nGrouped Products by Category (Query Syntax)");
            var groupedProducts = from p in products
                                  group p by p.Category;
            foreach (var categoryGroup in groupedProducts)
            {
                Console.WriteLine("Category: " + categoryGroup.Key);
                foreach (var product in categoryGroup)
                {
                    Console.WriteLine($"{product.Name}\t{product.Description}\t{product.Price}");
                }
            }

            // Example for Group By - Method Syntax
            Console.WriteLine("\nGrouped Products by Category (Method Syntax)");
            var groupedProducts2 = products.GroupBy(p => p.Category);
            foreach (var categoryGroup in groupedProducts2)
            {
                Console.WriteLine("Category: " + categoryGroup.Key);
                foreach (var product in categoryGroup)
                {
                    Console.WriteLine($"{product.Name}\t{product.Description}\t{product.Price}");
                }
            }
        }
    }
}
