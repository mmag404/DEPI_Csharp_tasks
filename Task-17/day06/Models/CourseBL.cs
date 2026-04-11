using System;
using day02.data.Contexts;
using day02.Models; 
using day02.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace day02.Models
{
    public class CourseBL
    {
        UniversityDBContext _context = new UniversityDBContext();


        // 🔹 Get All Courses
        public List<Course> GetAll()
        {
            return _context.Courses
                .Include(c => c.Department)
                .ToList();
        }

        // 🔹 Get By Id
        public Course GetById(int id)
        {
            return _context.Courses
                .Include(c => c.Department)
                .FirstOrDefault(c => c.Id == id);
        }

        // 🔹 Add
        public void Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        // 🔹 Update
        public void Update(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        // 🔹 Delete
        public void Delete(int id)
        {
            var course = GetById(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }

        // 🔥 Student Result Logic
        public StudentCourseResultVM GetStudentResult(int studentId, int courseId)
        {
            var result = _context.StuCrsRes
                .Include(x => x.Student)
                .Include(x => x.Course)
                .FirstOrDefault(x => x.StudentId == studentId && x.CourseId == courseId);

            if (result == null)
            {
                throw new Exception("No record found in StuCrsRes");
            }

            return new StudentCourseResultVM
            {
                StudentName = result.Student.Name,
                CourseName = result.Course.Name,
                Grade = result.Grade,
                StatusColor = result.Grade >= result.Course.MinDegree ? "green" : "red"
            };
        }
    }
}

