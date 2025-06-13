using System.ComponentModel.DataAnnotations;

namespace AssignmentAPI.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        public string DepartmentName { get; set; }

        public string DepartmentHead { get; set; }

        public int DepartmentStrength { get; set; }
    }
}

