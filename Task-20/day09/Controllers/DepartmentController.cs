using day02.Models;
using day02.Repository;
using day02.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace day02.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // ==========================
        // ShowAll Lifecycle
        // ==========================
        public IActionResult ShowAll()
        {
            var depts = _departmentRepository.GetAll();
            return View(depts);
        }

        // ==========================
        // ShowDetails Lifecycle
        // ==========================
        public IActionResult ShowDetails(int id)
        {
            var dept = _departmentRepository.GetById(id);

            if (dept == null)
                return NotFound();

            var vm = new DeptWithExtraInfoViewModel();

            vm.DepartmentId = dept.Id;
            vm.DepartmentName = dept.Name;

            // Department State
            vm.DepartmentState = dept.Students.Count > 50 ? "Main" : "Branch";

            // Students > 25
            vm.StudentsOver25 = dept.Students
                                    .Where(s => s.Age > 25)
                                    .ToList();

            return View(vm);
        }

        // ==========================
        // Add (GET)
        // ==========================
        public IActionResult Add()
        {
            return View(new Department());
        }

        // ==========================
        // Add (POST)
        // ==========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Department dept)
        {
            if (!string.IsNullOrEmpty(dept.Name) && !string.IsNullOrEmpty(dept.MgrName))
            {
                _departmentRepository.Add(dept);
                return RedirectToAction("ShowAll");
            }

            return View(dept);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Department dpt = _departmentRepository.GetById(id);
            return View(dpt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department newdpt)
        {
            if(ModelState.IsValid)
            {
                _departmentRepository.Update(newdpt);
                return RedirectToAction(nameof(ShowAll));
            }
            return View(newdpt);
        }
    }
}
