using day02.data.Contexts;
using day02.Models;
using Microsoft.EntityFrameworkCore;

namespace day02.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly UniversityDBContext _context;

        public DepartmentRepository(UniversityDBContext context)
        {
            _context = context;
        }

        public List<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments
                .Include(d => d.Students)
                .FirstOrDefault(d => d.Id == id);
        }

        public void Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Update(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var department = GetById(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }
    }
}
