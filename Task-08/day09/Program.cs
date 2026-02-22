using System;

namespace day09
{
    internal class Program
    {
        public enum Weekdays
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday
        }

        public enum Grades : short
        {
            A,   
            B,   
            C,   
            D,   
            E,   
            F = -1   
        }
        public enum Gender : byte
        {
            Male = 1,
            Female = 2
        }
        static void Main(string[] args)
        {

            #region Q1

            foreach (Weekdays day in Enum.GetValues(typeof(Weekdays)))
            {
                Console.WriteLine(day + " = " + (int)day);
            }

            /*
            Question Answer:

            It is recommended to explicitly assign values to enum members because sometimes
            we need specific numeric values, not just the default starting from 0.

            For example:
            - To match database values
            - To match protocol values
            - To avoid errors if enum order changes later

            Also it makes the code clearer and safer, because we know exactly what value
            each enum member represents instead of relying on automatic numbering.

            */
            #endregion

            #region Q2
            foreach (Grades grad in Enum.GetValues(typeof(Grades)))
            {
                Console.WriteLine(grad + " = " + (short)grad);
            }
            /*
            Question Answer:

            If we assign a value that exceeds the underlying type range,
            the compiler will give an error.

            For example, short range is from -32768 to 32767.
            If we try to assign 40000, it will not compile.

            This happens because enum values must fit inside the underlying type,
            otherwise it causes overflow and unsafe behavior.

            So C# prevents this at compile time to make the program safe.

            */
            #endregion


            #region Q3
            Person p1 = new Person("Mohamed", 20, "Computer Engineering");
            Person p2 = new Person("Ahmed", 22, "Information Systems");

            p1.PrintInfo();
            p2.PrintInfo();
            /*
                Question Answer:

                virtual keyword allows the property to be overridden in derived class.

                This means if another class inherits from Person,
                it can change the Department behavior using override.

                This supports runtime polymorphism and flexibility.

                */
            #endregion

            #region Q4
            Child emp = new Child(8000);

            emp.DisplaySalary();
            /*
            Question Answer:

            We cannot override a sealed property or method because sealed means
            this is the final implementation.

            It prevents further modification in derived classes.

            This is used when the developer wants to stop inheritance at certain level
            to protect the behavior and avoid unexpected changes.

            */

            #endregion



            #region Q5

            double perimeter = Utility.CalcRectanglePerimeter(8, 4);

            Console.WriteLine("Rectangle Perimeter = " + perimeter);


            /*
            Question Answer:

            Static members belong to the class itself, not to objects.
            So we can use them directly with class name like Utility.CalcRectanglePerimeter().

            Object members belong to an instance, so we must create object first.

            Static members are shared and do not depend on object data.
            Object members depend on the specific object.

            */

            #endregion


            #region Q6

            ComplexNumber c1 = new ComplexNumber() { Real = 3, Imag = 2 };
            ComplexNumber c2 = new ComplexNumber() { Real = 1, Imag = 4 };

            ComplexNumber result = c1 * c2;

            Console.WriteLine("First Complex Number: " + c1);
            Console.WriteLine("Second Complex Number: " + c2);
            Console.WriteLine("Multiplication Result: " + result);


            /*
            Question Answer:

            No, we cannot overload all operators in C#.

            Only predefined operators can be overloaded like +, -, *, /, ==, etc.

            Some operators cannot be overloaded such as:
            = , && , || , ?: , . , new , sizeof

            This is because these operators are related to language structure,
            memory handling, and runtime behavior, so C# does not allow changing them.

            */

            #endregion

            #region Q7

            Gender g1 = Gender.Male;

            // default enum uses int (4 bytes)
            int defaultEnumSize = sizeof(int);

            // modified enum uses byte (1 byte)
            int genderEnumSize = sizeof(byte);

            Console.WriteLine("Gender value = " + g1);

            Console.WriteLine("Size of default enum (int) = " + defaultEnumSize + " bytes");
            Console.WriteLine("Size of Gender enum (byte) = " + genderEnumSize + " bytes");


            /*
            Question Answer:

            We should change the underlying type when we want to save memory,
            especially if we have many enum variables.

            For example, byte uses 1 byte, while int uses 4 bytes.

            This is useful when:
            - We have large arrays of enum
            - Memory optimization is important
            - The enum values are small and fit in smaller type

            It improves memory efficiency.

            */

            #endregion


            #region Q8

            double c = 25;
            double f = Utility.CelsiusToFahrenheit(c);

            Console.WriteLine(c + " Celsius = " + f + " Fahrenheit");

            double f2 = 77;
            double c22 = Utility.FahrenheitToCelsius(f2);

            Console.WriteLine(f2 + " Fahrenheit = " + c22 + " Celsius");


            /*
            Question Answer:

            Static class cannot have instance constructors because we cannot create objects from static class.

            Static class is designed to contain only static members,
            and all members are accessed using the class name, not objects.

            So instance constructor is useless and not allowed.

            */

            #endregion



            #region Q9

            Console.Write("Enter grade (A, B, C, D, E, F): ");

            string input = Console.ReadLine();

            bool success = Enum.TryParse(input, out Grades grade);

            if (success)
            {
                Console.WriteLine("Parsed successfully: " + grade);
                Console.WriteLine("Numeric value: " + (short)grade);
            }
            else
            {
                Console.WriteLine("Invalid grade input.");
            }


            /*
            Question Answer:

            Enum.TryParse is safer than int.Parse because it does not throw exception if input is invalid.

            It returns true if conversion succeeds, and false if it fails.

            int.Parse will throw runtime exception if the input is invalid,
            which can crash the program.

            Enum.TryParse allows us to handle invalid input safely without crashing.

            */

            #endregion


            #region Q10

            Employee[] employees =
            {
    new Employee() { Id = 1, Name = "Mohamed", Salary = 5000 },
    new Employee() { Id = 2, Name = "Ahmed", Salary = 6000 },
    new Employee() { Id = 3, Name = "Ali", Salary = 7000 }
};

            Employee target = new Employee() { Id = 2, Name = "Ahmed", Salary = 6000 };

            int index = Helper<Employee>.SearchArr(employees, target);

            if (index != -1)
                Console.WriteLine("Employee found at index: " + index);
            else
                Console.WriteLine("Employee not found");


            /*
            Question Answer:

            Equals compares the actual content (values) of objects.

            == compares references for class, meaning it checks if both refer to same object in memory.

            For class:
            == compares reference
            Equals compares content (if overridden)

            For struct:
            == compares values directly
            Equals also compares values

            So overriding Equals allows correct logical comparison of objects.

            */

            #endregion



            #region Q11

            Employee em = new Employee()
            {
                Id = 1,
                Name = "Mohamed",
                Salary = 5000
            };

            Console.WriteLine(em);


            /*
            Question Answer:

            Overriding ToString is beneficial because it allows us to control
            how the object is represented as string.

            By default, ToString prints the class name only, which is not useful.

            After overriding ToString, it prints meaningful information like
            Id, Name, and Salary.

            This helps in debugging and displaying object data clearly.

            */

            #endregion


            #region Q12

            int maxInt = Helper<int>.Max(10, 20);
            Console.WriteLine("Max int = " + maxInt);

            double maxDouble = Helper<double>.Max(3.5, 2.8);
            Console.WriteLine("Max double = " + maxDouble);

            string maxString = Helper<string>.Max("Ahmed", "Mohamed");
            Console.WriteLine("Max string = " + maxString);


            /*
            Question Answer:

            Yes, generics can be constrained to specific types using where keyword.

            Example:
            where T : IComparable<T>

            This means T must implement IComparable interface.

            Constraints allow us to use methods safely like CompareTo,
            and prevent invalid types from being used.

            Example constraint:
            public static T Max<T>(T a, T b) where T : IComparable<T>

            */

            #endregion


            #region Q13

            // integer example
            int[] numbers = { 1, 2, 3, 2, 4, 2 };

            Helper<int>.ReplaceArray(numbers, 2, 99);

            Console.WriteLine("Integer array after replace:");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();


            // string example
            string[] names = { "Ali", "Ahmed", "Ali", "Mohamed" };

            Helper<string>.ReplaceArray(names, "Ali", "Omar");

            Console.WriteLine("String array after replace:");
            foreach (string name in names)
            {
                Console.Write(name + " ");
            }


            /*
            Question Answer:

            Generic class is a class that works with a specific type defined when creating the object.

            Example:
            Helper2<int>

            Generic method is a method that defines its own type parameter independent of the class.

            Example:
            public static T Max<T>(T a, T b)

            Generic class uses one type for all its methods.
            Generic method can use different types even inside non-generic class.

            */

            #endregion


            #region Q14

            Rectangle rect1 = new Rectangle { Length = 10, Width = 5 };
            Rectangle rect2 = new Rectangle { Length = 20, Width = 8 };

            Console.WriteLine("Before Swap:");
            Console.WriteLine("Rect1: " + rect1);
            Console.WriteLine("Rect2: " + rect2);

            // swap
            Helper<Rectangle>.SwapRectangle(ref rect1, ref rect2);

            Console.WriteLine("After Swap:");
            Console.WriteLine("Rect1: " + rect1);
            Console.WriteLine("Rect2: " + rect2);


            /*
            Question Answer:

            Generic swap method is preferable because it works with all types,
            so we do not need to write separate swap method for each type.

            It reduces code duplication and makes code reusable and cleaner.

            Example generic swap can work with int, string, Rectangle, etc.

            Non-generic swap works only with Rectangle.

            */

            #endregion

            #region Q15

            Department d1 = new Department { Id = 1, Name = "IT" };
            Department d2 = new Department { Id = 2, Name = "HR" };

            Employee[] employeess =
            {
    new Employee { Id = 1, Name = "Mohamed", Salary = 5000, Department = d1 },
    new Employee { Id = 2, Name = "Ahmed", Salary = 6000, Department = d2 },
    new Employee { Id = 3, Name = "Ali", Salary = 7000, Department = d1 }
};


            // employee object with target department
            Employee searchEmployee = new Employee
            {
                Department = new Department { Id = 2, Name = "HR" }
            };


            // use SearchArray
            int ix = Helper<Employee>.SearchArr(employees, searchEmployee);

            if (index != -1)
            {
                Console.WriteLine("Employee found:");
                Console.WriteLine(employees[index]);
            }
            else
            {
                Console.WriteLine("Employee not found");
            }


            /*
            Question Answer:

            Overriding Equals in Department allows comparison based on actual department values,
            not memory reference.

            So SearchArray can correctly find employees with same department
            even if Department objects are different instances.

            */

            #endregion



            #region Q16

            // struct comparison
            Circle s1 = new Circle { Radius = 5, Color = "Red" };
            Circle s2 = new Circle { Radius = 5, Color = "Red" };

            Console.WriteLine("Struct Equals: " + s1.Equals(s2));

            // == does not work by default for struct unless overloaded
            // Console.WriteLine(s1 == s2); // compile error


            // class comparison
            CircleClass c11 = new CircleClass { Radius = 5, Color = "Red" };
            CircleClass c222 = new CircleClass { Radius = 5, Color = "Red" };

            Console.WriteLine("Class Equals: " + c11.Equals(c222));

            Console.WriteLine("Class == : " + (c11 == c222)); // compares reference


            /*
            Question Answer:

            == is not implemented by default for structs because structs use value comparison
            and C# requires explicit definition of == operator to avoid ambiguity.

            Equals works by default for structs because it compares values.

            For class:
            == compares reference
            Equals compares content (if overridden)

            For struct:
            Equals compares values
            == must be overloaded manually if needed

            */

            #endregion








            /// part 02 ///
            #region Problem1

            // int example
            int[] nums = { 1, 2, 3, 4, 5 };

            int[] reversedNums = Helper<int>.ReverseArray(nums);

            Console.WriteLine("Reversed int array:");
            foreach (int n in reversedNums)
            {
                Console.Write(n + " ");
            }

            Console.WriteLine();


            // string example
            string[] nams = { "Ali", "Ahmed", "Mohamed" };

            string[] reversedNames = Helper<string>.ReverseArray(nams);

            Console.WriteLine("Reversed string array:");
            foreach (string name in reversedNames)
            {
                Console.Write(name + " ");
            }

            Console.WriteLine();


            // custom object example
            Employee[] emps=
            {
    new Employee { Id = 1, Name = "Ali", Salary = 5000 },
    new Employee { Id = 2, Name = "Ahmed", Salary = 6000 }
};

            Employee[] reversedEmployees = Helper<Employee>.ReverseArray(emps);

            Console.WriteLine("Reversed employee array:");
            foreach (Employee e in reversedEmployees)
            {
                Console.WriteLine(emp);
            }

            #endregion


            #region Problem2

            // int stack
            GenericStack<int> intStack = new GenericStack<int>(5);

            intStack.Push(10);
            intStack.Push(20);
            intStack.Push(30);

            Console.WriteLine("Peek int stack: " + intStack.Peek());

            Console.WriteLine("Pop int stack: " + intStack.Pop());

            Console.WriteLine("Peek after pop: " + intStack.Peek());

            Console.WriteLine();


            // string stack
            GenericStack<string> stringStack = new GenericStack<string>(5);

            stringStack.Push("Ali");
            stringStack.Push("Ahmed");

            Console.WriteLine("Peek string stack: " + stringStack.Peek());

            Console.WriteLine("Pop string stack: " + stringStack.Pop());

            #endregion



            #region Problem3

            // int example
            int[] numberss = { 10, 20, 30, 40 };

            Console.WriteLine("Before swap:");
            foreach (int n in numberss)
            {
                Console.Write(n + " ");
            }

            Console.WriteLine();

            Helper<int>.Swap(numbers, 1, 3);

            Console.WriteLine("After swap:");
            foreach (int n in numberss)
            {
                Console.Write(n + " ");
            }

            Console.WriteLine();


            // string example
            string[] namess = { "Ali", "Ahmed", "Mohamed" };

            Console.WriteLine("Before swap:");
            foreach (string name in namess)
            {
                Console.Write(name + " ");
            }

            Console.WriteLine();

            Helper<string>.Swap(namess, 0, 2);

            Console.WriteLine("After swap:");
            foreach (string name in namess)
            {
                Console.Write(name + " ");
            }

            #endregion


            #region Problem4

            // int example
            int[] numbrs = { 10, 50, 30, 80, 20 };

            int maxIntt = Helper<int>.MaxElement(numbrs);

            Console.WriteLine("Max int = " + maxIntt);


            // double example
            double[] values = { 3.5, 7.2, 1.8, 9.1 };

            double maxDoublee = Helper<double>.MaxElement(values);

            Console.WriteLine("Max double = " + maxDoublee);


            // string example
            string[] namss = { "Ali", "Mohamed", "Ahmed" };

            string maxStringg = Helper<string>.MaxElement(namss);

            Console.WriteLine("Max string = " + maxStringg);

            #endregion







        }
    }
}
