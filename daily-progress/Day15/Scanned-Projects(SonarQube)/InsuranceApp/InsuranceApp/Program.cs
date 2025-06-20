using InsuranceApp.Services;
using System;

namespace InsuranceApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            var customers = DataSample.GetCustomers();
            var insurances = DataSample.GetInsurances();

            QueryHelper.GetCustomersByCity(customers, "New York");
            QueryHelper.GetActivePoliciesOverPremium(insurances);
            QueryHelper.ListCustomerPolicies(customers, insurances);
            QueryHelper.TotalPremiumPerPolicyType(insurances);
            QueryHelper.FirstCustomerFromCity(customers, "Dallas");
            QueryHelper.AnyInactivePolicy(insurances);
            QueryHelper.AllPoliciesOver1000(insurances);
            QueryHelper.UniquePolicyTypes(insurances);
            QueryHelper.SkipTakeCustomers(customers);
            QueryHelper.TotalPremiumAmount(insurances);
            QueryHelper.CustomerWithOrWithoutPolicy(customers, insurances);
        }
    }
}

