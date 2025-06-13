using Microsoft.AspNetCore.Mvc;
using AssignmentAPI.Models;
using AssignmentAPI.Repositories;

namespace AssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public List<Department> GetDepartments()
        {
            return _departmentService.GetAllDepartments();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var department = _departmentService.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public IActionResult NewDepartment(Department department)
        {
            var id = _departmentService.AddDepartment(department);
            if (id == 0)
            {
                return BadRequest();
            }
            return Ok($"Department with {id} added");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Department department)
        {
            var result = _departmentService.UpdateDepartment(department);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _departmentService.DeleteDepartment(id);
            return Ok(result);
        }
    }
}
