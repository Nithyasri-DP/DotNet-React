using Microsoft.AspNetCore.Mvc;
using MVC_Demo.Models;
using System.Xml.Linq;

namespace MVC_Demo.Controllers
{
    public class DepartmentsController : Controller
    {
        public static List<Department> dept_list = new List<Department>()        
        {
            new Department() { Id = 102, Name = "Kaavya", Location = "Chennai"},
            new Department() { Id = 103, Name = "Arya", Location = "Delhi" },
            new Department() { Id = 104, Name = "Shravni", Location = "Theni" },
            new Department() { Id = 105, Name = "Preethi", Location = "Salem" }
        };

        //static List<Department> dept_list = new List<Department>();
        public IActionResult Dept()
        {
            //Department dept = new Department();
            //dept.Id = 101;
            //dept.Name = "Nithya";
            //dept.Location = "Namakkal";
            //dept_list = new List<Department>
            
            ViewData["Name"] = "Nithya";
            ViewData["Domain"] = "DotNetFullStack";
            ViewBag.CompanyName = "Hexaware";

            return View(dept_list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            dept_list.Add(department);
            return RedirectToAction("Dept");            
        }
        public IActionResult Details(int id)
        {
            var DepartmentDetails = dept_list.FirstOrDefault(d=>d.Id==id);
            return PartialView("_DepartmentDetails", DepartmentDetails);
        }
    }
}
