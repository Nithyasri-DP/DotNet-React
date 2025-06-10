using System.ComponentModel.DataAnnotations;

namespace EF_CodeFirstApproch.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Designation { get; set; }

        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}
