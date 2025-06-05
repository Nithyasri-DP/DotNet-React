using LSP_Demo.Models;

namespace LSP_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IFruit fruit = new Orange();
            Console.WriteLine("Color of Orange: " + fruit.GetColor());

            fruit = new Apple();
            Console.WriteLine("Color of Apple: " + fruit.GetColor());

            Console.ReadLine();
        }
    }
}
