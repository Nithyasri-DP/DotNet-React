using AssignmentAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentAPI.Repositories
{
    public class DepartmentService : IDepartmentService
    {
        public static List<Department> departments = new List<Department>()
        {
            new Department() { DepartmentId = 1, DepartmentName = "IT", DepartmentHead = "Avantika", DepartmentStrength = 20 },
            new Department() { DepartmentId = 2, DepartmentName = "HR", DepartmentHead = "Diya", DepartmentStrength = 10 },
            new Department() { DepartmentId = 3, DepartmentName = "Finance", DepartmentHead = "Heema", DepartmentStrength = 15 },
            new Department() { DepartmentId = 4, DepartmentName = "Marketing", DepartmentHead = "Kaavya", DepartmentStrength = 12 }
        };

        public List<Department> GetAllDepartments()
        {
            return departments;
        }

        public Department GetDepartment(int id)
        {
            var department = departments.Where(d => d.DepartmentId == id).FirstOrDefault();
            return department;
        }

        public int AddDepartment(Department department)
        {
            if (department != null)
            {
                departments.Add(department);
                return department.DepartmentId;
            }
            return 0;
        }

        public string UpdateDepartment(Department department)
        {
            var index = departments.FindIndex(d => d.DepartmentId == department.DepartmentId);
            if (index != -1)
            {
                departments[index] = department;
                return "Record Updated";
            }
            else
            {
                return "Record Not Updated";
            }
        }

        public string DeleteDepartment(int id)
        {
            var department = departments.Where(d => d.DepartmentId == id).FirstOrDefault();
            if (department != null)
            {
                departments.Remove(department);
                return $"{department.DepartmentName} Removed";
            }
            else
            {
                return "Given id not present in DB";
            }
        }
    }
}

