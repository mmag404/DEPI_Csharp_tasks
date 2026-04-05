using day02.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace day02.ViewModels
{
    public class StudentFormVM
    {
        public int Id { get; set; }   // used later in Edit

        public string Name { get; set; }

        public int Age { get; set; }

        public int DepartmentId { get; set; }

        [BindNever]
        [ValidateNever]
        public List<Department> Departments { get; set; }
    }
}
