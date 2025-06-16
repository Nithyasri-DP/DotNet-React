using Microsoft.AspNetCore.Mvc;
using WebAPI_Demo.DTOs;
using WebAPI_Demo.Models;
using WebAPI_Demo.Repositories;

namespace WebAPI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_studentService.GetAllStudents());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentService.GetStudent(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(StudentDTO dto)
        {
            var student = new Student
            {
                StudentName = dto.StudentName,
                StudentEmail = dto.StudentEmail,
                Age = dto.Age,
                Gender = dto.Gender,
                City = dto.City,
                CourseId = dto.CourseId
            };

            var created = _studentService.AddStudent(student);
            return Ok($"Student added with ID: {created}");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentDTO dto)
        {
            var student = new Student
            {
                StudentId = id,
                StudentName = dto.StudentName,
                StudentEmail = dto.StudentEmail,
                Age = dto.Age,
                Gender = dto.Gender,
                City = dto.City,
                CourseId = dto.CourseId
            };

            var result = _studentService.UpdateStudent(student);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _studentService.DeleteStudent(id);
            return Ok(result);
        }
    }
}
