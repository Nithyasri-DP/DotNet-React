using Microsoft.AspNetCore.Mvc;
using WebAPI_Demo.DTOs;
using WebAPI_Demo.Models;
using WebAPI_Demo.Repositories;

namespace WebAPI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_courseService.GetCourses());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpPost]
        public IActionResult Create(CourseDTO dto)
        {
            var course = new Course
            {
                CourseName = dto.CourseName,
                Duration = dto.Duration
            };

            var created = _courseService.AddCourse(course);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CourseDTO dto)
        {
            var course = new Course
            {
                Id = id,
                CourseName = dto.CourseName,
                Duration = dto.Duration
            };

            var result = _courseService.UpdateCourse(id, course);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _courseService.DeleteCourse(id);
            return Ok(result);
        }
    }
}
