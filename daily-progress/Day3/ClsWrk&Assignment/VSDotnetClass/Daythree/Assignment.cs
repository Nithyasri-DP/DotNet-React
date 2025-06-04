using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSDotnetClass.Daythree
{
    class Assignment
    {
        //1)
        public static void Question1()
        {
            Console.WriteLine("1) Hashtable of Student Roll Numbers and Names");

            Hashtable students = new Hashtable();
            students.Add(1, "Nila");
            students.Add(2, "Arun");
            students.Add(3, "Meera");
            students.Add(4, "Diya");
            students.Add(5, "Mrunalni");

            foreach (DictionaryEntry entry in students)
            {
                Console.WriteLine($"Roll No: {entry.Key}, Name: {entry.Value}");
            }
            Console.WriteLine(); 
        }

        //2)
        public static void Question2()
        {
            Console.WriteLine("2) ArrayList of Product Names");

            ArrayList products = new ArrayList();

            products.Add("Laptop");
            products.Add("Mouse");
            products.Add("Keyboard");
            products.Add("Monitor");
            products.Add("Printer");

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
        }

        //3)
        public static void Question3()
        {
            Console.WriteLine("3) Search for a key in Hashtable and update value");

            Hashtable students = new Hashtable();
            students.Add(1, "Nila");
            students.Add(2, "Arun");
            students.Add(3, "Meera");

            int searchKey = 2;   // Search for key
            if (students.ContainsKey(searchKey))
            {
                Console.WriteLine($"Before update: Roll No {searchKey} - {students[searchKey]}");                               
                students[searchKey] = "Arun Kumar";   // Updating value
                Console.WriteLine($"After update: Roll No {searchKey} - {students[searchKey]}");
            }
            else
            {
                Console.WriteLine($"Key {searchKey} not found.");
            }
            Console.WriteLine();
        }

        //4)
        public static void Question4()
        {
            Console.WriteLine("4) Remove item at index 2 and another by value from ArrayList");
            ArrayList products = new ArrayList();
            products.Add("Laptop");
            products.Add("Mouse");
            products.Add("Keyboard");
            products.Add("Monitor");
            products.Add("Printer");

            Console.WriteLine("Original List:");
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }

            products.RemoveAt(2); // Removes element at 2nd index
            products.Remove("Mouse"); // Removes first occurrence of Mouse
            Console.WriteLine("\nUpdated List after removals:");
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        //5)
        public static void Question5()
        {
            Console.WriteLine("5) Count and Clear a Hashtable");

            Hashtable students = new Hashtable();
            students.Add(1, "Nila");
            students.Add(2, "Arun");
            students.Add(3, "Meera");
            students.Add(4, "Diya");
            Console.WriteLine($"Total entries before clearing: {students.Count}");

            students.Clear();
            Console.WriteLine($"Total entries after clearing: {students.Count}");

            Console.WriteLine();
        }

        //6)
        public static void Question6()
        {
            Console.WriteLine("6) Sort and Reverse an ArrayList of Numbers");

            // Step 1: Create and add numbers to the ArrayList
            ArrayList numbers = new ArrayList();
            numbers.Add(30);
            numbers.Add(17);
            numbers.Add(19);
            numbers.Add(33);
            numbers.Add(2);

            Console.WriteLine("Original List:");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            numbers.Sort();
            Console.WriteLine("\nSorted List (Ascending):");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            numbers.Reverse();
            Console.WriteLine("\nReversed List (Descending):");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
        }

        //7)
        public static void Question7()
        {
            Console.WriteLine("7) Handling Duplicate Keys in Hashtable");

            Hashtable students = new Hashtable();
            students.Add(1, "Nila");
            students.Add(2, "Arun");
            students.Add(3, "Meera");

            try
            {
                students.Add(2, "Sanjay");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: Cannot add duplicate key. {ex.Message}");
            }
            Console.WriteLine("\nCurrent Hashtable:");
            foreach (DictionaryEntry entry in students)
            {
                Console.WriteLine($"Roll No: {entry.Key}, Name: {entry.Value}");
            }
            Console.WriteLine();
        }

        //8)
        public static void Question8()
        {
            Console.WriteLine("8) Insert a product at index 1 in an ArrayList");

            ArrayList products = new ArrayList();
            products.Add("Laptop");
            products.Add("Tablet");
            products.Add("Monitor");

            Console.WriteLine("Original Product List:");
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }

            products.Insert(1, "Smartphone"); //Inserting at index 1
            Console.WriteLine("\nUpdated Product List:");
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        //9)
        public static void Question9()
        {
            Console.WriteLine("9) Print only Keys and then only Values of a Hashtable");

            Hashtable students = new Hashtable();
            students.Add(101, "Asha");
            students.Add(102, "Bala");
            students.Add(103, "Charan");

            Console.WriteLine("\nKeys:");     // Print only keys
            foreach (var key in students.Keys)
            {
                Console.WriteLine(key);
            }
            
            Console.WriteLine("\nValues:");   // Print only values
            foreach (var value in students.Values)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();
        }
    }
}

