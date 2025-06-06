using InsuranceClaimProcessor.Interfaces;
using InsuranceClaimProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimProcessor.Services
{
    public class ClaimProcessor
    {
        private readonly IPolicyRepository _policyRepository;
        private readonly IClaimEvaluator _claimEvaluator;

        public ClaimProcessor(IPolicyRepository policyRepository, IClaimEvaluator claimEvaluator)
        {
            _policyRepository = policyRepository;
            _claimEvaluator = claimEvaluator;
        }

        public Claim SubmitClaim(Claim claim)
        {
            var policy = _policyRepository.GetPolicyById(claim.PolicyId);

            if (policy == null || !policy.IsActive)
            {
                claim.Status = "Rejected";
                return claim;
            }

            if (claim.ClaimedAmount > policy.MaxClaimAmount)
            {
                claim.Status = "Rejected";
                return claim;
            }

            claim.ApprovedAmount = _claimEvaluator.CalculatePayout(claim, policy);
            claim.Status = "Approved";
            return claim;
        }
    }
}
