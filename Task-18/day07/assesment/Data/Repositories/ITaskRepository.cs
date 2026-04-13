using assesment.Models;

namespace assesment.Data.Repositories
{
    public interface ITaskRepository
    {
        // Read
        IEnumerable<TaskItem> GetAll();
        TaskItem GetById(int id);

        // Create
        void Add(TaskItem task);

        // Update
        void Update(TaskItem task);

        // Delete
        void Delete(int id);

        // Save changes (important 🔥)
        void Save();
    }
}