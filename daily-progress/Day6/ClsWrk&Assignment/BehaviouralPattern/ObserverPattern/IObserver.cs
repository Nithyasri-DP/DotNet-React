using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviouralPattern.ObserverPattern
{
    public interface IObserver
    {
        void Update(decimal price);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    public class Stock : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private decimal price;

        public void RegisterObserver(IObserver observer) => observers.Add(observer);
        public void RemoveObserver(IObserver observer) => observers.Remove(observer);

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(price);
            }
        }

        public void SetPrice(decimal newPrice)
        {
            Console.WriteLine($"\nNew price of the stock is {newPrice:C}");
            price = newPrice;
            NotifyObservers();
        }
    }

    public class WebApp : IObserver
    {
        public void Update(decimal price)
        {
            Console.WriteLine($"Web App Notification: new price of the stock is {price:C}");
        }
    }

    public class MobileApp : IObserver
    {
        public void Update(decimal price)
        {
            Console.WriteLine($"Mobile App Notification: new price of the stock is {price:C}");
        }
    }
}
