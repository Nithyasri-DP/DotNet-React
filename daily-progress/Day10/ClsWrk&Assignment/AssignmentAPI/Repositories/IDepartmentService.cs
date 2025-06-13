using AssignmentAPI.Models;
using System.Collections.Generic;

namespace AssignmentAPI.Repositories
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartments();
        Department GetDepartment(int id);
        int AddDepartment(Department department);
        string UpdateDepartment(Department department);
        string DeleteDepartment(int id);
    }
}
