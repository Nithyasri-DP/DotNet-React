using WebAPI_Demo.Models;
using WebAPI_Demo.DTOs;

namespace WebAPI_Demo.Repositories
{
    public interface ICourseService
    {
        List<Course> GetCourses();
        Course GetCourseById(int id);
        Course AddCourse(Course course);
        string UpdateCourse(int id, Course course);
        string DeleteCourse(int id);
    }
}
