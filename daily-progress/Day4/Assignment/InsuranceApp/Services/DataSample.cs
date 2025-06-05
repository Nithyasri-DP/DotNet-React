using InsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApp.Services
{
    public static class DataSample
    {
        public static List<Customer> GetCustomers() => new List<Customer>
        {
            new Customer { CustomerId = 1, Name = "Keerthi", Age = 30, City = "New York" },
            new Customer { CustomerId = 2, Name = "Sindhu", Age = 25, City = "India" },
            new Customer { CustomerId = 3, Name = "Anitha", Age = 28, City = "Dallas" },
            new Customer { CustomerId = 4, Name = "Reena", Age = 24, City = "New York" },
            new Customer { CustomerId = 5, Name = "Ravi", Age = 28, City = "Russia" }
        };

        public static List<Insurance> GetInsurances() => new List<Insurance>
        {
            new Insurance { PolicyId = 101, CustomerId = 1, PolicyType = "Health", PremiumAmount = 5000, IsActive = true },
            new Insurance { PolicyId = 102, CustomerId = 2, PolicyType = "Life", PremiumAmount = 3000, IsActive = false },
            new Insurance { PolicyId = 103, CustomerId = 3, PolicyType = "Vehicle", PremiumAmount = 4500, IsActive = true },
            new Insurance { PolicyId = 104, CustomerId = 1, PolicyType = "Home", PremiumAmount = 2000, IsActive = true },
            new Insurance { PolicyId = 105, CustomerId = 4, PolicyType = "Life", PremiumAmount = 7000, IsActive = true }
        };
    }
}
