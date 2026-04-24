using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace day02.ViewModels
{
    public class CourseVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        public string Name { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Degree must be between 0 and 100")]
        public int Degree { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Min Degree must be between 0 and 100")]
        public int MinDegree { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }

        // 🔽 Dropdown
        [ValidateNever]
        public List<SelectListItem> Departments { get; set; }
    }
}
