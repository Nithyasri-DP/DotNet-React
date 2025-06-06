using BehaviouralPattern.ObserverPattern;
using BehaviouralPattern.MediatorPattern;
using BehaviouralPattern.ChainOfResponsibility;

namespace BehaviouralPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ObserverPatternDemo.Run();
            MediatorPatternDemo.Run();
            ChainOfResponsibilityDemo.Run();

            Console.ReadLine();
        }
    }
}
