using System;
using System.Linq;

namespace VSDotnetClass.Dayfour
{
    public class LinqSyn
    {
        public static void RunPrgm()
        {
            int[] numbers = { 9, 83, 233, 4, 867, 64 };

            Console.WriteLine("\nEven Numbers using Query syntax");
            var evenNumbers = from n in numbers
                              where n % 2 == 0
                              select n;
            foreach (var item in evenNumbers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nEven Numbers using Method syntax");
            var evenNumbers1 = numbers.Where(n => n % 2 == 0);
            foreach (var item in evenNumbers1)
            {
                Console.WriteLine(item);
            }
        }
    }
}
