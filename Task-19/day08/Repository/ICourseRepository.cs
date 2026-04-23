using day02.Models;
using day02.ViewModels;

namespace day02.Repository
{
    public interface ICourseRepository : IRepository<Course>
    {
        StudentCourseResultVM GetStudentResult(int studentId, int courseId);
    }
}
