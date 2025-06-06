using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimProcessor.Models
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string ? PolicyType { get; set; } 
        public bool IsActive { get; set; }
        public decimal MaxClaimAmount { get; set; }
    }
}
