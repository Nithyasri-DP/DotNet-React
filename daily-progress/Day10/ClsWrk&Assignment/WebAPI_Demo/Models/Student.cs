using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Demo.Models
{
    // [Table("tblStudent")]

    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string Course { get; set; }
    }
}

