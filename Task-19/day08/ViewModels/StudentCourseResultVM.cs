namespace day02.ViewModels
{
    public class StudentCourseResultVM
    {
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public int Grade { get; set; }

        // 🔥 Precomputed → NO logic in view
        public string StatusColor { get; set; } // "green" or "red"
    }
}
