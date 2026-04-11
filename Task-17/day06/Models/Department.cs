using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace day02.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Department name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Manager name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters allowed")]
        public string MgrName { get; set; }

        [ValidateNever]
        public ICollection<Student> Students { get; set; }
        [ValidateNever]

        public ICollection<Teacher> Teachers { get; set; }
        [ValidateNever]

        public ICollection<Course> Courses { get; set; }
    }
}
