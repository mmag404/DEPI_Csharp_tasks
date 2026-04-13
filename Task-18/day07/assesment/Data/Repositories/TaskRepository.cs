using assesment.Models;
using assesment.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace assesment.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Test06DbContext _context;


        public TaskRepository()
        {
            _context = new Test06DbContext();
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return _context.TaskItems.ToList();
        }

        public TaskItem GetById(int id)
        {
            return _context.TaskItems.Find(id);
        }

        public void Add(TaskItem task)
        {
            _context.TaskItems.Add(task);
        }

        public void Update(TaskItem task)
        {
            _context.TaskItems.Update(task);
        }

        public void Delete(int id)
        {
            var task = GetById(id);
            if (task != null)
                _context.TaskItems.Remove(task);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}