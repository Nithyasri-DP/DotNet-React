using InsuranceClaimProcessor.Interfaces;
using InsuranceClaimProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimProcessor.Services
{
    public class ClaimEvaluator : IClaimEvaluator
    {
        public decimal CalculatePayout(Claim claim, Policy policy)
        {
            if (policy.PolicyType == "Health")
            {
                return claim.ClaimedAmount * 0.8m; 
            }
            else if (policy.PolicyType == "Vehicle")
            {
                return claim.ClaimedAmount * 0.7m; 
            }
            else
            {
                return 0;
            }
        }
    }
}
