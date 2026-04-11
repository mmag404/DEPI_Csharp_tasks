using System;
using day02.data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace day02.Models
{
    public class DepartmentBL
    {
        UniversityDBContext context = new UniversityDBContext();


        // Get All Departments
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        // Get Department By Id WITH Students (navigation included)
        public Department GetById(int id)
        {
            return context.Departments
                          .Include(d => d.Students)
                          .FirstOrDefault(d => d.Id == id);
        }

        // Add Department
        public void Add(Department dept)
        {
            context.Departments.Add(dept);
            context.SaveChanges();
        }

        public void Update(Department dept)
        {
            context.Departments.Update(dept);
            context.SaveChanges();
        }
    }
}
