using EF_CodeFirstApproch.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace EF_CodeFirstApproch.Controllers
{
    public class DepartmentsController : Controller
    {
        public readonly ApplicationDBContext _context;
        public DepartmentsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // INDEX
        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Department department)
        {
            if (ModelState.IsValid)
            {
                // Save the department to the database
                // This is where you would typically call your service or repository to save the data
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // EDIT
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EF_CodeFirstApproch.Models.Department department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}


