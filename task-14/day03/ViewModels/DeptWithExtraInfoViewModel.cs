using day02.Models;

namespace day02.ViewModels
{
    public class DeptWithExtraInfoViewModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentState { get; set; }

        public List<Student> StudentsOver25 { get; set; }
    }
}
