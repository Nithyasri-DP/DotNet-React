using System.ComponentModel.DataAnnotations;

namespace WebAPI_Demo.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string CourseName { get; set; }

        public string Duration { get; set; }
        public bool isActive { get; set; } = true;

        // Navigation property
        internal ICollection<Student>? Students { get; set; } = new List<Student>();
    }
}
