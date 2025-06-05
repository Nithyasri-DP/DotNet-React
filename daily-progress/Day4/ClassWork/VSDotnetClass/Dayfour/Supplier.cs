using System;
using System.Collections.Generic;
using System.Linq;

namespace VSDotnetClass.Dayfour
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? Category { get; set; }

        static List<Supplier> suppliers = new List<Supplier>()
        {
            new Supplier() { SupplierId = 1, SupplierName = "iball", Category = "iball" },
            new Supplier() { SupplierId = 2, SupplierName = "Hp", Category = "Hp" },
            new Supplier() { SupplierId = 3, SupplierName = "DOMS", Category = "Stationary" },
            new Supplier() { SupplierId = 4, SupplierName = "cooling fan", Category = "Gamerz1" },
        };

        Product product = new Product();
        List<Product> products = new List<Product>();

        //---------------------------MORNING SESSION---------------------------------
        public void RunSupplier()
        {
            products = Product.GetAllProducts();

            // Inner Join
            var result = from p in products
                         join s in suppliers on p.Category equals s.Category
                         select new
                         {
                             ProductName = p.Name,
                             Supplier = s.SupplierName
                         };

            Console.WriteLine("\nINNER JOIN");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProductName} \t {item.Supplier}");
            }

            // Left Join
            var leftJoinResult = from s in suppliers
                                 join p in products on s.Category equals p.Category into prodGroup
                                 from pg in prodGroup.DefaultIfEmpty()
                                 select new
                                 {
                                     supplier = s.SupplierName,
                                     product = pg != null ? pg.Name : "No Products"
                                 };

            Console.WriteLine("\nLEFT JOIN");
            foreach (var item in leftJoinResult)
            {
                Console.WriteLine($"{item.supplier} supplies {item.product}");
            }

            // Group Join
            var groupJoinResult = from s in suppliers
                                  join p in products on s.Category equals p.Category into prodGroup
                                  select new
                                  {
                                      supplier = s.SupplierName,
                                      products = prodGroup
                                  };

            Console.WriteLine("\nGROUP JOIN");
            foreach (var group in groupJoinResult)
            {
                Console.WriteLine($"{group.supplier} supplies:");
                foreach (var p in group.products)
                {
                    Console.WriteLine($"- {p.Name}");
                }
            }

            // Anonymous Type Join
            var customJoin = from p in products
                             join s in suppliers on p.Category equals s.Category
                             where p.Price > 5000
                             select new
                             {
                                 Message = $"{s.SupplierName} provides {p.Name} for {p.Price}"
                             };

            Console.WriteLine("\nANONYMOUS TYPE JOIN");
            foreach (var item in customJoin)
            {
                Console.WriteLine(item.Message);
            }

            // Filtering by Category and Price
            var filteredResult = from p in products
                                 join s in suppliers on p.Category equals s.Category
                                 where p.Category == "Stationary" && p.Price < 5000
                                 select new
                                 {
                                     Product = p.Name,
                                     Price = p.Price,
                                     Supplier = s.SupplierName
                                 };

            Console.WriteLine("\nFILTERING BY CATEGORY AND PRICE");
            foreach (var item in filteredResult)
            {
                Console.WriteLine($"{item.Product} ({item.Price}) supplied by {item.Supplier}");
            }
        }

        //---------------------------AFTERNOON SESSION---------------------------------

        public void RunSetOperations()
        {
            // Distinct
            var uniqueProducts = products.Select(p => p.Category).Distinct();
            Console.WriteLine("\nUNIQUE CATEGORIES (Distinct)\n");
            foreach (var product in uniqueProducts)
            {
                Console.WriteLine(product);
            }

            // Intersect
            var commonCategories = products.Select(p => p.Category)
                .Intersect(suppliers.Select(s => s.Category));
            Console.WriteLine("\nCOMMON CATEGORIES (Intersect)\n");
            foreach (var item in commonCategories)
            {
                Console.WriteLine(item);
            }

            // Union
            var allNames = products.Select(p => p.Category)
                .Union(suppliers.Select(s => s.Category));
            Console.WriteLine("\nALL CATEGORIES (Union)\n");
            foreach (var item in allNames)
            {
                Console.WriteLine(item);
            }

            // Except
            var productsOnlyCategories = products.Select(p => p.Category)
                .Except(suppliers.Select(s => s.Category));
            Console.WriteLine("\nCATEGORIES IN PRODUCTS ONLY (Except)\n");
            foreach (var item in productsOnlyCategories)
            {
                Console.WriteLine(item);
            }
        }

        public void RunSkipEg()
        {
            // Skip & SkipWhile
            var skipFirst2 = products.Skip(2);
            var skipwhilePriceis1300 = products.SkipWhile(p => p.Price < 1300);

            Console.WriteLine("\nALL PRODUCTS\n");
            foreach (var item in products)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\nSkip(2)\n");
            foreach (var item in skipFirst2)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\nSkipWhile (Price < 1300)\n");
            foreach (var item in skipwhilePriceis1300)
            {
                Console.WriteLine(item.Name);
            }

            // Take & TakeWhile
            var first2products = products.Take(2);
            var takewhileCheapPrice = products.TakeWhile(p => p.Price < 2000);

            Console.WriteLine("\nTake (2)\n");
            foreach (var item in first2products)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\nTakeWhile (Price < 2000)\n");
            foreach (var item in takewhileCheapPrice)
            {
                Console.WriteLine(item.Name);
            }
        }

    }
}
