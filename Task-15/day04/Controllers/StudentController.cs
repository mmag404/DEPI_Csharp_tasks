using day02.Models;
using Microsoft.AspNetCore.Mvc;
using day02.ViewModels;


namespace day02.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBL = new StudentBL();
        DepartmentBL departmentBl = new DepartmentBL();

        public IActionResult ShowAll()
        {
            var students = studentBL.GetAll();
            return View(students);
        }

        public IActionResult ShowDetails(int id)
        {
            var student = studentBL.GetById(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        public IActionResult Add()
        {
            var vm = new StudentFormVM();

            vm.Departments = departmentBl.GetAll();

            return View("AddEdit", vm);
        }

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

                studentBL.Add(student);

                return RedirectToAction("ShowAll");
            }

            // IMPORTANT: reload departments if validation fails
            vm.Departments = departmentBl.GetAll();

            return View("AddEdit", vm);
        }


        public IActionResult Edit(int id)
        {
            var student = studentBL.GetById(id);

            if (student == null)
                return NotFound();

            StudentFormVM vm = new StudentFormVM()
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                DepartmentId = student.DepartmentId,

                // 🔥 IMPORTANT
                Departments =   departmentBl.GetAll()
            };

            return View("AddEdit", vm);
        }


        [HttpPost]
        public IActionResult Edit(StudentFormVM vm)
        {
            ModelState.Remove("Departments"); // keep your fix

            if (ModelState.IsValid)
            {
                var student = studentBL.GetById(vm.Id);

                if (student == null)
                    return NotFound();

                student.Name = vm.Name;
                student.Age = vm.Age;
                student.DepartmentId = vm.DepartmentId;

                studentBL.Update(student);

                return RedirectToAction("ShowAll");
            }

            vm.Departments = departmentBl.GetAll();

            return View("AddEdit", vm);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = studentBL.GetById(id);

            if (student == null)
                return NotFound();

            return View(student);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = studentBL.GetById(id);

            if (student != null)
            {
                studentBL.Delete(id);
            }

            return RedirectToAction("ShowAll");
        }
    }

}
