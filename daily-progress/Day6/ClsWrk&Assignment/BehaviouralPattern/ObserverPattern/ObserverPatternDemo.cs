using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviouralPattern.ObserverPattern
{
    public class ObserverPatternDemo
    {
        public static void Run()
        {
            Stock oneplusStock = new Stock();

            MobileApp mobile = new MobileApp();
            WebApp webApp = new WebApp();

            oneplusStock.RegisterObserver(mobile);
            oneplusStock.RegisterObserver(webApp);

            oneplusStock.SetPrice(48000);
            oneplusStock.SetPrice(39000);

            oneplusStock.RemoveObserver(webApp);
            oneplusStock.SetPrice(34000);
        }
    }
}
