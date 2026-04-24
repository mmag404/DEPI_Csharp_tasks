using day02.Models;
using day02.Repository;
using day02.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace day02.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public CourseController(ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
        }

        // =========================
        // 🔹 Helper: Departments Dropdown
        // =========================
        private List<SelectListItem> GetDepartments()
        {
            return _departmentRepository.GetAll()
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToList();
        }

        // =========================
        // 🔹 Index
        // =========================
        public IActionResult Index()
        {
            var courses = _courseRepository.GetAll();
            return View(courses);
        }

        // =========================
        // 🔹 Create (GET)
        // =========================
        public IActionResult Create()
        {
            var vm = new CourseVM
            {
                Departments = GetDepartments()
            };

            return View(vm);
        }

        // =========================
        // 🔹 Create (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Departments = GetDepartments(); // ⚠️ IMPORTANT
                return View(vm);
            }

            var course = new Course
            {
                Name = vm.Name,
                Degree = vm.Degree,
                MinDegree = vm.MinDegree,
                DepartmentId = vm.DepartmentId
            };

            _courseRepository.Add(course);

            return RedirectToAction(nameof(Index));
        }

        // =========================
        // 🔹 Edit (GET)
        // =========================
        public IActionResult Edit(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null) return NotFound();

            var vm = new CourseVM
            {
                Id = course.Id,
                Name = course.Name,
                Degree = course.Degree,
                MinDegree = course.MinDegree,
                DepartmentId = course.DepartmentId,
                Departments = GetDepartments()
            };

            return View(vm);
        }

        // =========================
        // 🔹 Edit (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CourseVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Departments = GetDepartments(); // ⚠️ IMPORTANT
                return View(vm);
            }

            var course = new Course
            {
                Id = vm.Id,
                Name = vm.Name,
                Degree = vm.Degree,
                MinDegree = vm.MinDegree,
                DepartmentId = vm.DepartmentId
            };

            _courseRepository.Update(course);

            return RedirectToAction(nameof(Index));
        }

        // =========================
        // 🔹 Delete (GET)
        // =========================
        public IActionResult Delete(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null) return NotFound();

            return View(course);
        }

        // =========================
        // 🔹 Delete (POST)
        // =========================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _courseRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // =========================
        // 🔹 Details (Optional)
        // =========================
        public IActionResult Details(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null) return NotFound();

            return View(course);
        }

        // =========================
        // 🔥 Student Result (Task)
        // =========================
        public IActionResult StudentResult(int studentId, int courseId)
        {
            var vm = _courseRepository.GetStudentResult(studentId, courseId);
            if (vm == null) return NotFound();

            return View(vm);
        }
    }
}