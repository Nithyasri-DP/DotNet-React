using Microsoft.EntityFrameworkCore;
using WebAPI_Demo.Contexts;
using WebAPI_Demo.Models;

namespace WebAPI_Demo.Repositories
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationContext _context;

        public StudentService(ApplicationContext context)
        {
            _context = context;
        }

        public int AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student.StudentId;
        }

        public string DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return "Student not found";

            _context.Students.Remove(student);
            _context.SaveChanges();
            return "Student deleted";
        }

        public List<Student> GetAllStudents() => _context.Students.Include(s => s.Course).ToList();

        public Student GetStudent(int id) => _context.Students.Include(s => s.Course).FirstOrDefault(s => s.StudentId == id);

        public string UpdateStudent(Student student)
        {
            var existing = _context.Students.Find(student.StudentId);
            if (existing == null) return "Student not found";

            existing.StudentName = student.StudentName;
            existing.StudentEmail = student.StudentEmail;
            existing.Age = student.Age;
            existing.Gender = student.Gender;
            existing.City = student.City;
            existing.CourseId = student.CourseId;

            _context.SaveChanges();
            return "Student updated";
        }
    }
}
