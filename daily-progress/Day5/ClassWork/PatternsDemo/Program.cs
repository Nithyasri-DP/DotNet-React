using PatternsDemo.Factory;
using PatternsDemo.Singleton;

namespace PatternsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose a design pattern demo to run:");
            Console.WriteLine("1 - Singleton");
            Console.WriteLine("2 - Factory");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                SingletonDemo.Run();
            }
            else if (choice == "2")
            {
                FactoryDemo.Run();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            Console.ReadLine();
        }
    }
}

