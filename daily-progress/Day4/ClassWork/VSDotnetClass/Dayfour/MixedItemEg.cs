using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VSDotnetClass.Dayfour
{
    public class MixedItemEg
    {
        public static void RunMixeditem()
        {
            IList mixedList = new ArrayList();

            mixedList.Add(10);
            mixedList.Add(20);
            mixedList.Add("Fransy");
            mixedList.Add("Test");
            mixedList.Add(new Product()
            {
                ProductId = 1,
                Name = "Test Product",
                Description = "Test Description",
                Price = 234
            });

            // Example for OfType operator
            var intList = from i in mixedList.OfType<int>()
                          select i;

            // method syntax
            var intList1 = mixedList.OfType<int>();

            var stringList = from s in mixedList.OfType<string>()
                             select s;

            // method syntax
            var stringList1 = mixedList.OfType<string>();

            var productList = from p in mixedList.OfType<Product>()
                              select p;

            // method syntax
            var productList1 = mixedList.OfType<Product>();

            Console.WriteLine("\nInteger List filtered from mixedList");
            foreach (var i in intList1)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\nString List filtered from mixedList");
            foreach (var i in stringList1)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\nProduct List filtered from mixedList");
            foreach (var i in productList1)
            {
                Console.WriteLine($"{i.ProductId}\t{i.Name}\t{i.Price}");
            }

            Console.ReadLine();
        }
    }
}
