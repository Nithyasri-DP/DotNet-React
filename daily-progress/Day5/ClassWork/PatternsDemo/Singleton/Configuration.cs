using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsDemo.Singleton
{
    public class Configuration
    {
        private static Configuration _instance;
        private static readonly object _instanceLock = new object();

        public string Setting { get; private set; }

        private Configuration()  // Make constructor private to enforce Singleton
        {
            Setting = "Default Configuration Value";
            Console.WriteLine("Configuration Loaded");
        }

        public static Configuration Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new Configuration();
                    }
                }
                return _instance;
            }
        }
    }
}
