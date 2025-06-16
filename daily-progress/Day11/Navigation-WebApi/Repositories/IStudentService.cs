using WebAPI_Demo.Models;
using WebAPI_Demo.DTOs;

namespace WebAPI_Demo.Repositories
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student GetStudent(int id);
        int AddStudent(Student student);
        string UpdateStudent(Student student);
        string DeleteStudent(int id);
    }
}
