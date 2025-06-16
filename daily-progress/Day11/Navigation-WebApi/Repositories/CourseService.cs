using Microsoft.EntityFrameworkCore;
using WebAPI_Demo.Contexts;
using WebAPI_Demo.Models;

namespace WebAPI_Demo.Repositories
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationContext _context;
        public CourseService(ApplicationContext context)
        {
            _context = context;
        }

        public Course AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public string DeleteCourse(int id)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id == id);
            if (course != null)
            {
                course.isActive = false;
                _context.Entry(course).State = EntityState.Modified;
                _context.SaveChanges();
                return $"Course id {id} removed.";
            }
            return "Course not found.";
        }

        public Course GetCourseById(int id) => _context.Courses.FirstOrDefault(x => x.Id == id);

        public List<Course> GetCourses() => _context.Courses.Where(c => c.isActive).ToList();

        public string UpdateCourse(int id, Course course)
        {
            var existing = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (existing == null) return "Course not found";

            existing.CourseName = course.CourseName;
            existing.Duration = course.Duration;
            _context.SaveChanges();
            return "Course updated.";
        }
    }
}
