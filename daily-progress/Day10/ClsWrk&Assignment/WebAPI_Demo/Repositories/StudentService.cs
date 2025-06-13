using WebAPI_Demo.Models;
using WebAPI_Demo.Repositories;

namespace SimpleWebApiDemo.Repositories
{
    public class StudentService : IStudentService
    {
        public static List<Student> students = new List<Student>()
        {
            new Student() { StudentId = 1, StudentEmail = "Anu@gmail.com", StudentName = "Anu", Course = "Angular" },
            new Student() { StudentId = 2, StudentEmail = "Diya@gmail.com", StudentName = "Diya", Course = "AWS" },
            new Student() { StudentId = 3, StudentEmail = "Krithi@gmail.com", StudentName = "Krithi", Course = "DevOps" },
            new Student() { StudentId = 4, StudentEmail = "Nila@gmail.com", StudentName = "Nila", Course = "React" },           
        };

        public int AddStudent(Student student)
        {
            if (student != null)
            {
                students.Add(student);
                return student.StudentId;
            }
            else
            {
                return 0;
            }
        }

        public string DeleteStudent(int id)
        {
            var student = students.Where(s => s.StudentId == id).FirstOrDefault();
            if (student != null)
            {
                students.Remove(student);
                return $"{student.StudentName} Removed";
            }
            else
            {
                return "Given id not present in DB";
            }
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudent(int id)
        {
            var student = students.Where(s => s.StudentId == id).FirstOrDefault();
            if (student == null)
                return null;

            return student;
        }

        public string UpdateStudent(Student student)
        {
            var index = students.FindIndex(s => s.StudentId == student.StudentId);
            if (index != -1)
            {
                students[index] = student;
                return "Record Updated";
            }
            else
            {
                return "Record not updated";
            }
        }
    }
}
