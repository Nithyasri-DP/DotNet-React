using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("GetAllStudents")]
        public async Task<List<Student>> GetStudents()
        {
            try
            {
                return _studentService.GetAllStudents();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetStudentbyid/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var student = _studentService.GetStudent(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("CreateStudent")]
        public IActionResult NewStudent(Student student)
        {
            var id = _studentService.AddStudent(student);
            if (id == 0)
            {
                return BadRequest();
            }
            return Ok($"Student with {id} added");
        }

        [HttpPut("UpdateStudent/{id}")]
        public IActionResult Put(int id, Student student)
        {
            var result = _studentService.UpdateStudent(student);
            return Ok(result);
        }

        [HttpDelete("DeleteStudent/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _studentService.DeleteStudent(id);
            return Ok(result);
        }
    }
}
