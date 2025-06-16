using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI_Demo.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }

        [EmailAddress]
        public string StudentEmail { get; set; }

        [Range(21, 65, ErrorMessage = "Age must be between 21 to 65")]
        public int Age { get; set; }

        public string Gender { get; set; }
        public string City { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public Course? Course { get; set; }
    }
}
