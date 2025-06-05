using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsDemo.Singleton
{
    public static class SingletonDemo
    {
        public static void Run()
        {
            var config1 = Configuration.Instance;
            Console.WriteLine("Config1 setting: " + config1.Setting);

            var config2 = Configuration.Instance;
            Console.WriteLine("Config2 setting: " + config2.Setting);
        }
    }
}
