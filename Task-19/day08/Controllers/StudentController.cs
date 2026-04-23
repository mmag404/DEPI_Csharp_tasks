using day02.Models;
using day02.Repository;
using day02.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace day02.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public StudentController(IStudentRepository studentRepository, IDepartmentRepository departmentRepository)
        {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
        }

        public IActionResult ShowAll()
        {
            var students = _studentRepository.GetAll();
            return View(students);
        }

        public IActionResult ShowDetails(int id)
        {
            var student = _studentRepository.GetById(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        public IActionResult Add()
        {
            var vm = new StudentFormVM
            {
                Departments = _departmentRepository.GetAll()
                    .Select(d => new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.Name
                    }).ToList()
            };

            return View("AddEdit", vm);
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Add(StudentFormVM vm)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student()
                {
                    Name = vm.Name,
                    Age = vm.Age,
                    DepartmentId = vm.DepartmentId
                };

                _studentRepository.Add(student);

                return RedirectToAction("ShowAll");
            }

            // reload dropdown
            vm.Departments = _departmentRepository.GetAll()
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToList();

            return View("AddEdit", vm);
        }


        public IActionResult Edit(int id)
        {
            var student = _studentRepository.GetById(id);

            if (student == null)
                return NotFound();

            var vm = new StudentFormVM
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                DepartmentId = student.DepartmentId,
                Departments = _departmentRepository.GetAll()
                    .Select(d => new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.Name
                    }).ToList()
            };

            return View("AddEdit", vm);
        }


        [HttpPost]
        [HttpPost]
        public IActionResult Edit(StudentFormVM vm)
        {
            if (ModelState.IsValid)
            {
                var student = _studentRepository.GetById(vm.Id);

                if (student == null)
                    return NotFound();

                student.Name = vm.Name;
                student.Age = vm.Age;
                student.DepartmentId = vm.DepartmentId;

                _studentRepository.Update(student);

                return RedirectToAction("ShowAll");
            }

            vm.Departments = _departmentRepository.GetAll()
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToList();

            return View("AddEdit", vm);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _studentRepository.GetById(id);

            if (student == null)
                return NotFound();

            return View(student);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _studentRepository.GetById(id);

            if (student != null)
            {
                _studentRepository.Delete(id);
            }

            return RedirectToAction("ShowAll");
        }
    }

}
