using InsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApp.Services
{
    public static class QueryHelper
    {
        // 1. Get all customers from a given city
        public static void GetCustomersByCity(List<Customer> customers, string city)
        {
            var result = customers.Where(c => c.City == city);

            Console.WriteLine($"\nQ1: Customers from {city}:");
            foreach (var c in result)
            {
                Console.WriteLine($"{c.Name} ({c.Age} years old)");
            }
        }

        // 2. Select all active insurance policies with premium over 4000
        public static void GetActivePoliciesOverPremium(List<Insurance> insurances)
        {
            var result = insurances.Where(i => i.IsActive && i.PremiumAmount > 4000);

            Console.WriteLine("\nQ2: Active policies with premium over 4000:");
            foreach (var i in result)
            {
                Console.WriteLine($"{i.PolicyType} - {i.PremiumAmount}");
            }
        }

        // 3. List all customer names, their policy type, and premium amount
        public static void ListCustomerPolicies(List<Customer> customers, List<Insurance> insurances)
        {
            var result = from c in customers
                         join i in insurances on c.CustomerId equals i.CustomerId
                         select new { c.Name, i.PolicyType, i.PremiumAmount };

            Console.WriteLine("\nQ3: Customer Policy Details:");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} - {item.PolicyType} - {item.PremiumAmount}");
            }
        }

        // 4. Calculate total premium for each policy type
        public static void TotalPremiumPerPolicyType(List<Insurance> insurances)
        {
            var result = insurances
                         .GroupBy(i => i.PolicyType)
                         .Select(g => new { PolicyType = g.Key, Total = g.Sum(x => x.PremiumAmount) });

            Console.WriteLine("\nQ4: Total Premium by Policy Type:");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.PolicyType}: {item.Total}");
            }
        }

        // 5. Display first customer from given city (e.g., Dallas)
        public static void FirstCustomerFromCity(List<Customer> customers, string city)
        {
            var result = customers.FirstOrDefault(c => c.City == city);

            Console.WriteLine($"\nQ5: First Customer from {city}:");
            if (result != null)
                Console.WriteLine($"{result.Name} - Age: {result.Age}");
            else
                Console.WriteLine("No customer found.");
        }

        // 6. Check if any policy is inactive
        public static void AnyInactivePolicy(List<Insurance> insurances)
        {
            bool hasInactive = insurances.Any(i => !i.IsActive);

            Console.WriteLine("\nQ6. There " + (hasInactive ? "is at least one inactive policy." : "are no inactive policies."));
        }

        // 7. Check if all policies have premium > 1000
        public static void AllPoliciesOver1000(List<Insurance> insurances)
        {
            bool allOver = insurances.All(i => i.PremiumAmount > 1000);

            Console.WriteLine("\nQ7. All policies have a premium amount greater than 1000: " + (allOver ? "Yes" : "No"));
        }

        // 8. Display unique policy types
        public static void UniquePolicyTypes(List<Insurance> insurances)
        {
            var types = insurances.Select(i => i.PolicyType).Distinct();

            Console.WriteLine("\nQ8: Unique Policy Types:");
            foreach (var type in types)
            {
                Console.WriteLine(type);
            }
        }

        // 9. Skip first 2 customers and take next 3
        public static void SkipTakeCustomers(List<Customer> customers)
        {
            var result = customers.Skip(2).Take(3);

            Console.WriteLine("\nQ9: Three Customers after skipping first two:");
            foreach (var c in result)
            {
                Console.WriteLine(c.Name);
            }
        }

        // 10. Total Premium Amount
        public static void TotalPremiumAmount(List<Insurance> insurances)
        {
            var total = insurances.Sum(i => i.PremiumAmount);

            Console.WriteLine($"\nQ10: Total Premium Amount: {total}");
        }

        // 11. List all customer names and their policy type (if no policy: 'No Policy')
        public static void CustomerWithOrWithoutPolicy(List<Customer> customers, List<Insurance> insurances)
        {
            var result = from c in customers
                         join i in insurances on c.CustomerId equals i.CustomerId into joined
                         from policy in joined.DefaultIfEmpty()
                         select new
                         {
                             c.Name,
                             PolicyType = policy != null ? policy.PolicyType : "No Policy"
                         };

            Console.WriteLine("\nQ11: Customers and their Policy Types:");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} - {item.PolicyType}");
            }
        }
    }
}
