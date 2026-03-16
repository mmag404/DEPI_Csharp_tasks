using day02.Models;
using Microsoft.AspNetCore.Mvc;

namespace day02.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBL = new StudentBL();

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
    }
}
