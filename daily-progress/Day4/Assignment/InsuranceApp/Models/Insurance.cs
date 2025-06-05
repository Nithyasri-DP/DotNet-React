using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApp.Models
{
    public class Insurance
    {
        public int PolicyId { get; set; }
        public int CustomerId { get; set; }  // Foreign key reference to Customer
        public string? PolicyType { get; set; }
        public decimal PremiumAmount { get; set; }
        public bool IsActive { get; set; }
    }
}
