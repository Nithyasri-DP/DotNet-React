using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimProcessor.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public int PolicyId { get; set; }
        public string? ClaimType { get; set; }
        public decimal ClaimedAmount { get; set; }
        public string? Status { get; set; } 
        public decimal? ApprovedAmount { get; set; }
    }
}
