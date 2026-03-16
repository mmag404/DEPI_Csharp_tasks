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
    }
}
