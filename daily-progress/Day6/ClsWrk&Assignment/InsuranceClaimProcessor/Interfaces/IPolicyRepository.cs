using InsuranceClaimProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimProcessor.Interfaces
{
    public interface IPolicyRepository
    {
        Policy GetPolicyById(int policyId);
    }
}
