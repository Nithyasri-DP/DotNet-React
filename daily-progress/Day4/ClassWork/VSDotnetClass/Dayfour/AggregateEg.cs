using System;
using System.Collections.Generic;
using System.Linq;

namespace VSDotnetClass.Dayfour
{
    public static class AggregateEg
    {
        public static void RunAggregate()
        {
            var products = Product.GetAllProducts();

            // First & FirstOrDefault
            var firstExpensiveProduct = products.FirstOrDefault(p => p.Price > 10000);
            var firstCheapProduct = products.First(p => p.Price < 500);

            Console.WriteLine($"First Expensive Product = {firstExpensiveProduct?.Name ?? "None"}");
            Console.WriteLine($"First Cheap Product = {firstCheapProduct.Name}");

            // Single & SingleOrDefault
            var onlyProjector = products.Single(p => p.Name == "Projector");
            var onlyScanner = products.SingleOrDefault(p => p.Name == "Scanner");

            Console.WriteLine($"Only Projector = {onlyProjector.Name}");
            if (onlyScanner != null)
                Console.WriteLine($"Only Scanner = {onlyScanner.Name}");
            else
                Console.WriteLine("Only Scanner = Not Found");

            // Any and All
            bool anyStationary = products.Any(p => p.Category == "Stationary");
            bool allCostly = products.All(p => p.Price > 500);

            Console.WriteLine($"Any product as Stationary = {anyStationary}");
            Console.WriteLine($"All products are priced > 500 = {allCostly}");

            // Aggregate Functions
            int totalPrice = products.Sum(p => p.Price);
            int totalCount = products.Count();
            int maxPrice = products.Max(p => p.Price);
            int minPrice = products.Min(p => p.Price);
            double avgPrice = products.Average(p => p.Price);

            Console.WriteLine($"Total Price = {totalPrice}");
            Console.WriteLine($"Total Product Count = {totalCount}");
            Console.WriteLine($"Maximum Price = {maxPrice}");
            Console.WriteLine($"Minimum Price = {minPrice}");
            Console.WriteLine($"Average Price = {avgPrice}");
        }

        // -----------------PRGM ON PROGRAM.CS---------------
        public static void RunElementOperators()
        {
            // Sample lists: integers, strings (with null), and an empty list
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> stringList = new List<string>() { null, "One", "Three", "Two", "Five", "Four" };
            IList<string> emptyList = new List<string>();

            // FIRST() - returns the first element, throws exception if list is empty
            Console.WriteLine($"First Element in intList: {intList.First()}");
            Console.WriteLine($"First even number in intList: {intList.First(i => i % 2 == 0)}");
            Console.WriteLine($"First element in stringList: {stringList.First()}");

            // FIRSTORDEFAULT() - returns first element or default (null/0) if list is empty
            Console.WriteLine($"FirstOrDefault in intList: {intList.FirstOrDefault()}");
            Console.WriteLine($"FirstOrDefault even number: {intList.FirstOrDefault(i => i % 2 == 0)}");
            Console.WriteLine($"FirstOrDefault in stringList: {stringList.FirstOrDefault()}");
            Console.WriteLine($"FirstOrDefault in emptyList: {emptyList.FirstOrDefault()}");

            // LAST() - returns the last element, throws exception if list is empty
            Console.WriteLine($"Last element in intList: {intList.Last()}");
            Console.WriteLine($"Last even number in intList: {intList.Last(i => i % 2 == 0)}");
            Console.WriteLine($"Last element in stringList: {stringList.Last()}");
        }
    }
}

