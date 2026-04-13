using Microsoft.AspNetCore.Mvc;
using assesment.Data.Repositories;
using assesment.Models;

namespace assesment.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly ITaskRepository _repo;

        // 🔥 Dependency Injection happens here
        public TaskItemController()
        {
            _repo = new TaskRepository();
        }

        // ===================== READ =====================

        // GET: /TaskItem
        public IActionResult Index()
        {
            var tasks = _repo.GetAll();
            return View(tasks);
        }

        // GET: /TaskItem/Details/5
        public IActionResult Details(int id)
        {
            var task = _repo.GetById(id);
            if (task == null) return NotFound();

            return View(task);
        }

        // ===================== CREATE =====================

        // GET: /TaskItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /TaskItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(task);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(task);
        }

        // ===================== UPDATE =====================

        // GET: /TaskItem/Edit/5
        public IActionResult Edit(int id)
        {
            var task = _repo.GetById(id);
            if (task == null) return NotFound();

            return View(task);
        }

        // POST: /TaskItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TaskItem task)
        {
            if (id != task.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                _repo.Update(task);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(task);
        }

        // ===================== DELETE =====================

        // GET: /TaskItem/Delete/5
        public IActionResult Delete(int id)
        {
            var task = _repo.GetById(id);
            if (task == null) return NotFound();

            return View(task);
        }

        // POST: /TaskItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            _repo.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}