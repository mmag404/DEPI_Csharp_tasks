using day02.data.Contexts;
using day02.Repository;
using Microsoft.EntityFrameworkCore;

namespace day02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register DbContext with DI
            builder.Services.AddDbContext<UniversityDBContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register Repositories with DI
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // =========================
            // Custom Conventional Routes
            // =========================

            // Students routes
            app.MapControllerRoute(
                name: "students",
                pattern: "students",
                defaults: new { controller = "Student", action = "ShowAll" });

            app.MapControllerRoute(
                name: "studentDetails",
                pattern: "students/details/{id}",
                defaults: new { controller = "Student", action = "ShowDetails" });

            app.MapControllerRoute(
                name: "studentAdd",
                pattern: "students/add",
                defaults: new { controller = "Student", action = "Add" });

            app.MapControllerRoute(
                name: "studentEdit",
                pattern: "students/edit/{id}",
                defaults: new { controller = "Student", action = "Edit" });

            app.MapControllerRoute(
                name: "studentDelete",
                pattern: "students/delete/{id}",
                defaults: new { controller = "Student", action = "Delete" });

            // Courses routes
            app.MapControllerRoute(
                name: "courses",
                pattern: "courses",
                defaults: new { controller = "Course", action = "Index" });

            app.MapControllerRoute(
                name: "courseDetails",
                pattern: "courses/details/{id}",
                defaults: new { controller = "Course", action = "Details" });

            app.MapControllerRoute(
                name: "courseCreate",
                pattern: "courses/create",
                defaults: new { controller = "Course", action = "Create" });

            app.MapControllerRoute(
                name: "courseEdit",
                pattern: "courses/edit/{id}",
                defaults: new { controller = "Course", action = "Edit" });

            app.MapControllerRoute(
                name: "courseDelete",
                pattern: "courses/delete/{id}",
                defaults: new { controller = "Course", action = "Delete" });

            app.MapControllerRoute(
                name: "courseResult",
                pattern: "courses/result/{studentId}/{courseId}",
                defaults: new { controller = "Course", action = "StudentResult" });

            // Departments routes
            app.MapControllerRoute(
                name: "departments",
                pattern: "departments",
                defaults: new { controller = "Department", action = "ShowAll" });

            app.MapControllerRoute(
                name: "departmentDetails",
                pattern: "departments/details/{id}",
                defaults: new { controller = "Department", action = "ShowDetails" });

            app.MapControllerRoute(
                name: "departmentAdd",
                pattern: "departments/add",
                defaults: new { controller = "Department", action = "Add" });

            app.MapControllerRoute(
                name: "departmentEdit",
                pattern: "departments/edit/{id}",
                defaults: new { controller = "Department", action = "Edit" });

            // Default route (must be last)
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}