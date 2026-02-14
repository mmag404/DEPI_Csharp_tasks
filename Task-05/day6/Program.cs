using System;

namespace day6
{
    internal class Program
    {
        static void ModifyPoint(Point p)
        {
            p.X = 100;
            p.Y = 200;
        }

        static void ModifyEmployee(Employee e)
        {
            e.SetName("Modified");
        }

        static void Main(string[] args)
        {
            #region q2 test call
            TestInsideSameAssembly testInsideSameAssembly = new TestInsideSameAssembly();
            testInsideSameAssembly.Test();
            #endregion


            #region q3
            Employee emp = new Employee(1, "Ali", 5000);

            Console.WriteLine(emp.GetName());

            emp.SetName("Omar");
            Console.WriteLine(emp.GetName());

            emp.Salary = -1000;    // test validation
            Console.WriteLine(emp.Salary);

            /*
            Answer:

            Encapsulation is critical because it protects data from direct access.
            It allows control over how data is read or modified.

            Using private fields prevents unauthorized changes.
            Methods and properties allow validation and controlled access.

            This improves security, maintainability, and reduces errors in software design.
            */


            #endregion



            #region q4
            Point p1 = new Point(5);
            Point p2 = new Point(3, 7);

            Console.WriteLine($"P1: ({p1.X}, {p1.Y})");
            Console.WriteLine($"P2: ({p2.X}, {p2.Y})");

            /*
            Answer:

            Constructors in structs are special methods used to initialize
            the struct fields when an object is created.

            They must assign values to all fields.

            Structs always have an implicit default constructor that
            initializes fields to their default values (0, null, etc.).

            Constructor overloading means having more than one constructor
            with different parameters.
            */
            #endregion



            #region q5
            Point point1 = new Point(2, 4);
            Point point2 = new Point(7, 9);
            Point point3 = new Point(-1, 5);

            Console.WriteLine(point1);
            Console.WriteLine(point2);
            Console.WriteLine(point3);

            /*
            Answer:

            Overriding ToString() improves readability because it controls how
            the object is displayed when printed.

            Instead of printing the type name, it shows meaningful information
            about the object's state.

            This makes debugging easier and the output clearer.
            */
            #endregion


            #region q6
            Point pt = new Point(1, 2);
            Employee empp = new Employee(1, "Ali", 5000);   

            ModifyPoint(pt);
            ModifyEmployee(empp);

            Console.WriteLine($"Point: ({pt.X}, {pt.Y})");
            Console.WriteLine($"Employee Name: {empp.GetName()}");
            #endregion


        }
    }
}
