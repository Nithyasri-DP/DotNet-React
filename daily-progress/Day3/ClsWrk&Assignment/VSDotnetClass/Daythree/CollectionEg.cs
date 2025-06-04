using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSDotnetClass.Daythree
{
    internal class CollectionEg
    {
        public static void Runprgm()
        {
            ArrayList myarrayList = new ArrayList();

            myarrayList.Add(100);
            myarrayList.Add("Nithya");
            myarrayList.Add('S');
            myarrayList.Add(3.14);

            Console.WriteLine("List of items in myArrayList:");
            foreach (var item in myarrayList)
            {
                Console.WriteLine(item);
            }

            ArrayList myarrayList2 = new ArrayList() { "Apple", "300", "Bread" };
            myarrayList.AddRange(myarrayList2);

            Console.WriteLine("\nAfter AddRange (adding myarrayList2):");
            foreach (var item in myarrayList)
            {
                Console.WriteLine(item);
            }

            myarrayList.Insert(1, "New inserted Item");

            Console.WriteLine("\nAfter Insert at index 1:");
            foreach (var item in myarrayList)
            {
                Console.WriteLine(item);
            }

            ArrayList veggies = new ArrayList() { "Carrot", "Beans", "Potato", "Peas" };
            myarrayList.InsertRange(0, veggies);
            Console.WriteLine("\nAfter InsertRange(0, veggies):");
            foreach (var item in myarrayList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\nCount: {myarrayList.Count}");
            myarrayList.Remove("New inserted Item");
        }
    }
}
