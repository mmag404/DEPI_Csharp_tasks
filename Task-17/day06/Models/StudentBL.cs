using day02.data.Contexts;

namespace day02.Models
{
    public class StudentBL
    {
        UniversityDBContext context = new UniversityDBContext();

        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return context.Students.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Student st)
        {
            context.Students.Add(st);
            context.SaveChanges();
        }

        public void Update(Student st)
        {
            context.Students.Update(st);
            context.SaveChanges();
        }

        public void Delete(int id) { 
            context.Students.Remove(GetById(id));
            context.SaveChanges();
        }
    }
}
