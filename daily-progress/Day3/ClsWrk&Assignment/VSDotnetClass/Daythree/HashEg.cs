using System;
using System.Collections;

namespace VSDotnetClass.Daythree
{
    class HashEg
    {
        public static void HashRun()
        {
            Hashtable hs = new Hashtable();

            hs.Add("F1", "Apple");
            hs.Add("F2", "Orange");
            hs.Add("F4", "Mosambi");
            hs.Add("F3", "Pomegranate");
            hs["F7"] = "Jackfruit";
            hs["F5"] = "Pineapple";
            hs["F6"] = "Amla";

            Console.WriteLine("The First Fruit: {0}", hs["F1"]);
            Console.WriteLine("The Last Fruit: {0}", hs["F6"]);
            Console.WriteLine("Total no. of items in hs: " + hs.Count);

            hs.Add(10, "Grapes");
            Console.WriteLine("Total no. of items after adding int key: " + hs.Count);
            Console.WriteLine("The fruit with key 10: {0}", hs[10]);

            Console.WriteLine("Is key 'F6' present? " + hs.Contains("F6"));
            Console.WriteLine("Is key 'F5' present? " + hs.ContainsKey("F5"));

            Console.WriteLine("\nAfter removing two items from hashtable:");
            hs.Remove("F5");
            hs.Remove("F3");

            Console.WriteLine("Total no. of items after removal: " + hs.Count);

            hs.Add("F5", "xxx");
            Console.WriteLine("Added F5 again with value 'xxx': " + hs["F5"]);

            // Copying Keys from Hashtable to an Array
            Console.WriteLine();
            Console.WriteLine("Copying Keys from Hashtable to an Array:");
            object[] h2 = new object[10];
            hs.Keys.CopyTo(h2, 1);
            Console.WriteLine("Array Elements (Keys):");
            foreach (var item in h2)
            {
                if (item != null)
                    Console.WriteLine(item);
            }

            // Copying Values from Hashtable to an Array
            Console.WriteLine();
            Console.WriteLine("Copying Values from Hashtable to an Array:");
            object[] A3 = new object[10];
            hs.Values.CopyTo(A3, 0);
            Console.WriteLine("Array Elements (Values):");
            foreach (var item in A3)
            {
                if (item != null)
                    Console.WriteLine(item);
            }

            // Display keys and values
            Console.WriteLine("\nKeys and Values");
            foreach (DictionaryEntry item in hs)
            {
                Console.WriteLine("{0} : {1}", item.Key, item.Value);
            }

            // Clear all items
            Console.WriteLine("\nTotal no. of items in hs before Clear(): " + hs.Count);
            hs.Clear();
            Console.WriteLine("Total no. of items in hs after Clear(): " + hs.Count);

            Console.ReadKey();
        }
    }
}
