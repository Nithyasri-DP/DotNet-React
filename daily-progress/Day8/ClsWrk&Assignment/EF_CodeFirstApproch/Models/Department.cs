using System.ComponentModel.DataAnnotations;

namespace EF_CodeFirstApproch.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Display(Name = "Department Name")]
        public string Name { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }
    }
}

