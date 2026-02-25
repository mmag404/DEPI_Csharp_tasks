using System;
using System.Collections.Generic;
using System.Linq;

namespace day10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region q1
            Employee[] employees = new Employee[]
        {
            new Employee(1,"Ahmed", 7000),
            new Employee(1,"Mohamed", 5000),
            new Employee(1,"Sara", 9000),
            new Employee(1,"Ali", 6000)
        };


            // print before sorting
            Console.WriteLine("Before Sorting:");
            PrintEmployees(employees);


            // call generic sorting algorithm
            SortingAlgorithm<Employee>.Sort(employees);


            // print after sorting
            Console.WriteLine("\nAfter Sorting (Ascending by Salary):");
            PrintEmployees(employees);

            /*
                Question Answer:

                Using generic sorting algorithm has several benefits.

                First, it can be used with any data type such as int, string, or Employee without rewriting the sorting code.

                Second, it provides type safety. This means the compiler ensures the correct type is used, which reduces runtime errors.

                Third, it improves code reuse. We write the sorting logic once and use it everywhere.

                Finally, it makes the code easier to maintain and cleaner because we avoid duplicated sorting implementations for different types.
                */
            #endregion


            #region Q2

            // create integer array
            int[] numbers = { 5, 2, 9, 1, 7, 3 };


            // print before sorting
            Console.WriteLine("Before Sorting:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();


            // sort in descending order using lambda expression
            // lambda returns true when left element is smaller than right element
            // this will swap them to move larger values to the left
            SortingTwo<int>.Sort(numbers, (a, b) => a < b);


            // print after sorting
            Console.WriteLine("After Sorting (Descending):");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();


            /*
            Question Answer:

            Lambda expressions improve readability because they allow us to write short and clear logic directly where it is needed,
            instead of creating a separate method. This makes the code easier to understand quickly.

            They also improve flexibility because we can easily change the sorting behavior without modifying the sorting algorithm itself.
            For example, we can sort ascending, descending, or based on custom conditions just by changing the lambda expression.

            This makes the sorting method more reusable and powerful since the comparison logic is dynamic and not fixed.
            */

            #endregion


            #region Q3

            string[] words = { "computer", "hi", "apple", "cat", "a" };

            Console.WriteLine("Before Sorting:");
            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(words[i] + " ");
            }
            Console.WriteLine();


            // sort by length ascending using lambda comparer
            // swap when left string is longer than right string
            SortingTwo<string>.Sort(words, (a, b) => a.Length > b.Length);


            Console.WriteLine("After Sorting (Ascending by Length):");
            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(words[i] + " ");
            }
            Console.WriteLine();


            /*
            Question Answer:

            Using a dynamic comparer function is important because different data types may require different sorting logic.

            For example, integers are sorted by numeric value, strings can be sorted alphabetically or by length,
            and objects like Employee can be sorted by salary or name.

            A dynamic comparer allows us to define the comparison logic at runtime without changing the sorting algorithm itself.
            This makes the sorting function reusable, flexible, and suitable for many different types and conditions.
            */

            #endregion


            #region Q4

            // create Manager array
            Manager[] managers = new Manager[]
            {
    new Manager(1,"Ahmed", 15000),
    new Manager(1,"Sara", 12000),
    new Manager(1,"Mohamed", 18000),
    new Manager(1,"Ali", 14000)
            };


            Console.WriteLine("Before Sorting Managers:");
            for (int i = 0; i < managers.Length; i++)
            {
                Console.WriteLine($"Name: {managers[i].Name}, Salary: {managers[i].Salary}");
            }


            // sort managers using generic sorting algorithm
            SortingAlgorithm<Manager>.Sort(managers);


            Console.WriteLine("\nAfter Sorting Managers (Ascending by Salary):");
            for (int i = 0; i < managers.Length; i++)
            {
                Console.WriteLine($"Name: {managers[i].Name}, Salary: {managers[i].Salary}");
            }


            /*
            Question Answer:

            Implementing IComparable<T> in derived classes allows each class to define its own comparison logic.

            This enables the sorting algorithm to compare objects correctly based on their specific type.
            For example, Manager objects can be compared using Salary just like Employee objects.

            It also allows generic sorting algorithms to work with derived classes without modification,
            because the sorting algorithm only requires that the type implements IComparable<T>.

            This makes sorting flexible, reusable, and supports polymorphism.
            */

            #endregion


            #region Q5

            // create employee array
            Employee[] employeesByNameLength = new Employee[]
            {
    new Employee(1,"Ali", 5000),
    new Employee(1,"Mohamed", 7000),
    new Employee(1,"Sara", 6000),
    new Employee(1,"Abdelrahman", 8000)
            };


            Console.WriteLine("Before Sorting by Name Length:");
            for (int i = 0; i < employeesByNameLength.Length; i++)
            {
                Console.WriteLine($"Name: {employeesByNameLength[i].Name}, Salary: {employeesByNameLength[i].Salary}");
            }


            // create Func delegate to compare employees based on name length
            // swap when left name is longer than right name (ascending order)
            Func<Employee, Employee, bool> compareByNameLength = (a, b) => a.Name.Length > b.Name.Length;


            // use delegate in sorting
            SortingTwo<Employee>.Sort(employeesByNameLength, compareByNameLength);


            Console.WriteLine("\nAfter Sorting by Name Length (Ascending):");
            for (int i = 0; i < employeesByNameLength.Length; i++)
            {
                Console.WriteLine($"Name: {employeesByNameLength[i].Name}, Salary: {employeesByNameLength[i].Salary}");
            }


            /*
            Question Answer:

            The main advantage of using built-in delegates like Func<T, T, TResult> is that they allow
            us to define comparison logic in a flexible and reusable way without creating separate classes or methods.

            They make the code shorter and easier to read because we can use lambda expressions directly.

            They also improve generic programming by allowing the same function to work with different data types,
            since the comparison logic can be passed as a parameter dynamically.

            This increases code reusability and makes the program more flexible and easier to maintain.
            */

            #endregion


            #region Q6

            int[] numberss = { 9, 3, 7, 1, 5 };

            Console.WriteLine("Before Sorting:");
            for (int i = 0; i < numberss.Length; i++)
            {
                Console.Write(numberss[i] + " ");
            }
            Console.WriteLine();


            // --------- Anonymous Function ---------

            // using delegate keyword (anonymous function)
            SortingTwo<int>.Sort(numberss, delegate (int a, int b)
            {
                return a > b;   // swap when left is greater → ascending order
            });

            Console.WriteLine("\nAfter Sorting (Anonymous Function - Ascending):");
            for (int i = 0; i < numberss.Length; i++)
            {
                Console.Write(numberss[i] + " ");
            }
            Console.WriteLine();


            // reset array
            numbers = new int[] { 9, 3, 7, 1, 5 };


            // --------- Lambda Expression ---------

            // using lambda expression
            SortingTwo<int>.Sort(numbers, (a, b) => a > b);

            Console.WriteLine("\nAfter Sorting (Lambda Expression - Ascending):");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();


            /*
            Question Answer:

            Anonymous functions and lambda expressions both allow us to define a method inline
            without creating a separate named method.

            The main difference is readability. Lambda expressions are shorter and cleaner,
            so they make the code easier to read and understand quickly.

            Anonymous functions use the "delegate" keyword and usually take more lines,
            so they look slightly heavier.

            In terms of efficiency, both are almost the same because the compiler internally
            translates lambda expressions into delegate objects.

            So lambda expressions are preferred mainly because they are more concise and readable.
            */

            #endregion


            #region Q7

            int[] numberz = { 10, 20, 30, 40 };

            Console.WriteLine("Before Swap:");
            for (int i = 0; i < numberz.Length; i++)
            {
                Console.Write(numberz[i] + " ");
            }
            Console.WriteLine();


            // swap first and last elements using standalone generic Swap
            Swap<int>(ref numberz[0], ref numberz[3]);


            Console.WriteLine("\nAfter Swap:");
            for (int i = 0; i < numberz.Length; i++)
            {
                Console.Write(numberz[i] + " ");
            }
            Console.WriteLine();


            /*
            Question Answer:

            Generic methods are beneficial because they allow the same function to work with different data types
            without rewriting the code.

            For example, the same Swap method can be used with int, string, or Employee objects.

            This improves code reuse, reduces duplication, and makes utility functions more flexible and reusable.

            It also improves maintainability because we only write and maintain one version of the method.
            */

            #endregion


            #region Q8

            Employee[] employeesMultiSort = new Employee[]
            {
    new Employee(1,"Ahmed", 7000),
    new Employee(1,"Sara", 5000),
    new Employee(1,"Mohamed", 7000),
    new Employee(1,"Ali", 5000),
    new Employee(1,"Ziad", 9000)
            };

            Console.WriteLine("Before Sorting (Salary then Name):");
            for (int i = 0; i < employeesMultiSort.Length; i++)
            {
                Console.WriteLine($"Name: {employeesMultiSort[i].Name}, Salary: {employeesMultiSort[i].Salary}");
            }


            // custom comparer using anonymous function
            // first compare by Salary
            // if salaries are equal, compare by Name alphabetically
            SortingTwo<Employee>.Sort(employeesMultiSort, delegate (Employee a, Employee b)
            {
                if (a.Salary > b.Salary)
                    return true;

                if (a.Salary < b.Salary)
                    return false;

                // salaries equal → compare by name
                return string.Compare(a.Name, b.Name) > 0;
            });


            Console.WriteLine("\nAfter Sorting (Salary then Name):");
            for (int i = 0; i < employeesMultiSort.Length; i++)
            {
                Console.WriteLine($"Name: {employeesMultiSort[i].Name}, Salary: {employeesMultiSort[i].Salary}");
            }


            /*
            Question Answer:

            The main challenge of multi-criteria sorting is that the comparison logic becomes more complex,
            because we must check more than one condition in the correct order.

            For example, we first compare Salary, and only if Salary is equal, we compare Name.
            This requires careful implementation to ensure correct sorting behavior.

            The benefit is that it allows more precise and meaningful sorting of objects.
            It ensures consistent ordering even when primary values are equal.

            It also increases flexibility, because generic methods can handle complex sorting logic
            without modifying the sorting algorithm itself.
            */

            #endregion


            #region Q9

            // demonstrate with value type (int)
            int defaultInt = GetDefault<int>();

            Console.WriteLine("Default value for int:");
            Console.WriteLine(defaultInt);


            // demonstrate with reference type (Employee)
            Employee defaultEmployee = GetDefault<Employee>();

            Console.WriteLine("\nDefault value for Employee:");
            if (defaultEmployee == null)
                Console.WriteLine("null");
            else
                Console.WriteLine(defaultEmployee);


            // demonstrate with another reference type (string)
            string defaultString = GetDefault<string>();

            Console.WriteLine("\nDefault value for string:");
            if (defaultString == null)
                Console.WriteLine("null");
            else
                Console.WriteLine(defaultString);


            /*
            Question Answer:

            The default(T) keyword is crucial in generic programming because it allows us to assign
            a default value to a variable without knowing its type in advance.

            For value types like int, default(T) returns 0, because value types always have a default numeric value.

            For reference types like string or Employee, default(T) returns null, because reference types
            store memory addresses, and the default state means no object is assigned.

            This makes generic code safe and flexible, since we can initialize variables correctly
            regardless of their type.
            */

            #endregion


            #region Q10

            Employee[] originalEmployees = new Employee[]
            {
    new Employee(1,"Ahmed", 7000),
    new Employee(1,"Sara", 5000),
    new Employee(1,"Mohamed", 9000),
    new Employee(1,"Ali", 6000)
            };


            Console.WriteLine("Original Array Before Cloning:");
            for (int i = 0; i < originalEmployees.Length; i++)
            {
                Console.WriteLine($"Name: {originalEmployees[i].Name}, Salary: {originalEmployees[i].Salary}");
            }


            // clone array using ICloneable
            Employee[] clonedEmployees = new Employee[originalEmployees.Length];

            for (int i = 0; i < originalEmployees.Length; i++)
            {
                clonedEmployees[i] = (Employee)originalEmployees[i].Clone();
            }


            // sort cloned array
            SortingAlgorithm<Employee>.Sort(clonedEmployees);


            Console.WriteLine("\nCloned Array After Sorting:");
            for (int i = 0; i < clonedEmployees.Length; i++)
            {
                Console.WriteLine($"Name: {clonedEmployees[i].Name}, Salary: {clonedEmployees[i].Salary}");
            }


            Console.WriteLine("\nOriginal Array After Sorting Clone (unchanged):");
            for (int i = 0; i < originalEmployees.Length; i++)
            {
                Console.WriteLine($"Name: {originalEmployees[i].Name}, Salary: {originalEmployees[i].Salary}");
            }


            /*
            Question Answer:

            Constraints in generic programming ensure type safety by restricting the types that can be used
            with generic classes or methods.

            For example, requiring ICloneable ensures that the Clone() method exists, so the compiler guarantees
            that cloning can be performed safely without runtime errors.

            This improves reliability because errors are detected at compile time instead of runtime.

            It also allows generic methods to safely use specific functionality like Clone(), CompareTo(),
            or other required methods.
            */

            #endregion


            #region Q11

            // create list of strings
            List<string> wordss = new List<string>()
{
    "ahmed",
    "mohamed",
    "sara",
    "ali"
};


            Console.WriteLine("Original List:");
            for (int i = 0; i < wordss.Count; i++)
            {
                Console.WriteLine(wordss[i]);
            }


            // delegate instance for uppercase transformation
            StringTransformer toUpper = ToUpperCase;

            // apply transformation
            List<string> upperResult = ApplyTransformation(wordss, toUpper);

            Console.WriteLine("\nAfter Uppercase Transformation:");
            for (int i = 0; i < upperResult.Count; i++)
            {
                Console.WriteLine(upperResult[i]);
            }


            // delegate instance for reverse transformation
            StringTransformer reverse = ReverseString;

            // apply transformation
            List<string> reverseResult = ApplyTransformation(wordss, reverse);

            Console.WriteLine("\nAfter Reverse Transformation:");
            for (int i = 0; i < reverseResult.Count; i++)
            {
                Console.WriteLine(reverseResult[i]);
            }


            /*
            Question Answer:

            Delegates allow us to pass different transformation logic to the same function,
            which makes the code more flexible and reusable.

            Instead of writing separate functions for uppercase, reverse, or other transformations,
            we can use one function and change the behavior using delegates.

            This follows functional programming style, where functions can be treated as data
            and passed as parameters.

            It improves modularity, reduces code duplication, and makes the program easier to extend.
            */

            #endregion

            #region Q12

            // create delegate instances for different operations
            MathOperation add = Add;
            MathOperation subtract = Subtract;
            MathOperation multiply = Multiply;
            MathOperation divide = Divide;


            // test values
            int a = 20;
            int b = 5;


            // perform operations using same function but different delegates
            Console.WriteLine("Addition:");
            Console.WriteLine($"{a} + {b} = {PerformOperation(a, b, add)}");

            Console.WriteLine("\nSubtraction:");
            Console.WriteLine($"{a} - {b} = {PerformOperation(a, b, subtract)}");

            Console.WriteLine("\nMultiplication:");
            Console.WriteLine($"{a} * {b} = {PerformOperation(a, b, multiply)}");

            Console.WriteLine("\nDivision:");
            Console.WriteLine($"{a} / {b} = {PerformOperation(a, b, divide)}");


            /*
            Question Answer:

            Delegates promote code reusability because we can use the same function to perform
            different operations without rewriting the logic.

            For example, the PerformOperation function is written only once, but it can perform
            addition, subtraction, multiplication, or division depending on the delegate passed.

            This improves flexibility because we can easily add new operations without modifying
            existing code. We only need to create a new method and pass it as a delegate.

            This makes the code cleaner, easier to maintain, and more modular.
            */

            #endregion


            #region Q13

            // create list of integers
            List<int> numbersz = new List<int>() { 1, 2, 3, 4, 5 };

            Console.WriteLine("Original Integer List:");
            for (int i = 0; i < numbersz.Count; i++)
            {
                Console.WriteLine(numbersz[i]);
            }


            // create delegate instance to convert int to string
            Transformer<int, string> intToString = ConvertIntToString;

            // transform list<int> to list<string>
            List<string> stringNumbers = TransformList(numbersz, intToString);

            Console.WriteLine("\nAfter Converting Integers To Strings:");
            for (int i = 0; i < stringNumbers.Count; i++)
            {
                Console.WriteLine(stringNumbers[i]);
            }


            // another example: convert int to squared value (int -> int)
            Transformer<int, int> square = SquareNumber;

            List<int> squaredNumbers = TransformList(numbersz, square);

            Console.WriteLine("\nAfter Squaring Numbers:");
            for (int i = 0; i < squaredNumbers.Count; i++)
            {
                Console.WriteLine(squaredNumbers[i]);
            }


            /*
            Question Answer:

            Generic delegates allow us to write transformation logic that works with any data type,
            without rewriting the method for each specific type.

            For example, the same TransformList method can convert integers to strings,
            or integers to integers, or even Employee objects to something else.

            This improves code reusability because we write the transformation method only once.

            It also increases flexibility, since we can change the behavior by simply passing
            a different delegate without modifying the core logic.

            This makes the code more modular and easier to extend.
            */

            #endregion

            #region Q14

            // create list of integers
            List<int> numbers4 = new List<int>() { 2, 4, 6, 8 };

            Console.WriteLine("Original Numbers:");
            for (int i = 0; i < numbers4.Count; i++)
            {
                Console.WriteLine(numbers4[i]);
            }


            // create Func delegate to calculate square
            Func<int, int> square4= x => x * x;


            // apply delegate to list
            List<int> squaredNumbers4 = ApplyFunc(numbers4, square4);

            Console.WriteLine("\nSquared Numbers:");
            for (int i = 0; i < squaredNumbers4.Count; i++)
            {
                Console.WriteLine(squaredNumbers4[i]);
            }


            /*
            Question Answer:

            Func simplifies delegate usage because we do not need to declare a custom delegate type.

            Instead of writing a separate delegate definition, we can directly use Func<T, TResult>
            which is already defined in .NET.

            It makes the code shorter and cleaner, especially when combined with lambda expressions.

            It also improves readability and reduces boilerplate code, while still allowing
            flexible and reusable behavior.
            */

            #endregion


            #region Q15

            // create list of strings
            List<string> names = new List<string>()
{
    "Ahmed",
    "Sara",
    "Mohamed",
    "Ali"
};


            // create Action delegate that prints string
            Action<string> print = s => Console.WriteLine(s);


            Console.WriteLine("Printing Names Using Action:");
            ApplyAction(names, print);


            /*
            Question Answer:

            Action is preferred for operations that do not return values because it clearly
            represents a method that performs an operation without producing a result.

            Instead of creating a custom delegate with void return type,
            we can use the built-in Action<T> delegate.

            This makes the code cleaner and more readable, and it avoids unnecessary delegate declarations.

            It also improves consistency in generic programming since Func is used for returning values,
            and Action is used when no value is returned.
            */

            #endregion


            #region Q16

            // create list of integers
            List<int> numbers6 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine("Original Numbers:");
            for (int i = 0; i < numbers6.Count; i++)
            {
                Console.Write(numbers6[i] + " ");
            }
            Console.WriteLine();


            // create Predicate delegate to check if number is even
            Predicate<int> isEven = n => n % 2 == 0;


            // filter list using predicate
            List<int> evenNumbers = FilterList(numbers6, isEven);


            Console.WriteLine("\nEven Numbers:");
            for (int i = 0; i < evenNumbers.Count; i++)
            {
                Console.Write(evenNumbers[i] + " ");
            }
            Console.WriteLine();


            /*
            Question Answer:

            Predicates play an important role in functional programming because they represent
            conditions that return true or false.

            They allow us to separate filtering logic from the main program logic,
            which makes the code cleaner and easier to understand.

            For example, instead of writing filtering logic inside the loop every time,
            we can define a predicate once and reuse it.

            This improves code clarity, reusability, and makes the program more modular.
            */

            #endregion

            #region Q17

            // create list of strings
            List<string> words7 = new List<string>()
{
    "Ahmed",
    "Ali",
    "Mohamed",
    "Sara",
    "Salma",
    "Omar"
};

            Console.WriteLine("Original List:");
            for (int i = 0; i < words7.Count; i++)
            {
                Console.WriteLine(words7[i]);
            }


            // filter using anonymous function (strings that start with 'A')
            List<string> startsWithA = FilterStrings(words7, delegate (string s)
            {
                return s.StartsWith("A");
            });

            Console.WriteLine("\nStrings that start with 'A':");
            for (int i = 0; i < startsWithA.Count; i++)
            {
                Console.WriteLine(startsWithA[i]);
            }


            // filter using anonymous function (strings that contain "ar")
            List<string> containsAr = FilterStrings(words7, delegate (string s)
            {
                return s.Contains("ar");
            });

            Console.WriteLine("\nStrings that contain 'ar':");
            for (int i = 0; i < containsAr.Count; i++)
            {
                Console.WriteLine(containsAr[i]);
            }


            /*
            Question Answer:

            Anonymous functions improve code modularity because they allow us to define custom logic
            directly where it is needed, without creating separate named methods.

            This makes the code more flexible, since we can easily change the condition for filtering
            without modifying the filtering function itself.

            They also improve customization, because different conditions can be applied using the same
            function, which reduces code duplication and makes the program easier to maintain.
            */

            #endregion



            #region Q18

  


            // addition using anonymous function
            int addResult = PerformMathOperation(a, b, delegate (int x, int y)
            {
                return x + y;
            });

            Console.WriteLine("Addition Result:");
            Console.WriteLine($"{a} + {b} = {addResult}");


            // subtraction using anonymous function
            int subtractResult = PerformMathOperation(a, b, delegate (int x, int y)
            {
                return x - y;
            });

            Console.WriteLine("\nSubtraction Result:");
            Console.WriteLine($"{a} - {b} = {subtractResult}");


            // multiplication using anonymous function
            int multiplyResult = PerformMathOperation(a, b, delegate (int x, int y)
            {
                return x * y;
            });

            Console.WriteLine("\nMultiplication Result:");
            Console.WriteLine($"{a} * {b} = {multiplyResult}");



            /*
            Question Answer:

            Anonymous functions are preferred when the operation is simple and used only once,
            so there is no need to create a separate named method.

            They make the code shorter and keep the logic close to where it is used,
            which improves readability.

            They are also useful when passing custom behavior dynamically,
            especially in delegate-based functions.

            However, if the operation is complex or reused many times,
            named methods are better for clarity and maintainability.
            */

            #endregion

            #region Q19

            // create list of strings
            List<string> words9 = new List<string>()
{
    "Ali",
    "Ahmed",
    "Omar",
    "Salma",
    "Eman",
    "Ziad"
};

            Console.WriteLine("Original List:");
            for (int i = 0; i < words9.Count; i++)
            {
                Console.WriteLine(words9[i]);
            }


            // filter using lambda expression (length greater than 3)
            List<string> lengthGreaterThan3 = FilterStrings(words9, s => s.Length > 3);

            Console.WriteLine("\nStrings with length greater than 3:");
            for (int i = 0; i < lengthGreaterThan3.Count; i++)
            {
                Console.WriteLine(lengthGreaterThan3[i]);
            }


            // filter using lambda expression (contains letter 'e')
            List<string> containsE = FilterStrings(words9, s => s.Contains("e") || s.Contains("E"));

            Console.WriteLine("\nStrings that contain letter 'e':");
            for (int i = 0; i < containsE.Count; i++)
            {
                Console.WriteLine(containsE[i]);
            }


            /*
            Question Answer:

            Lambda expressions are essential in modern C# because they allow writing functions in a short
            and clear way without creating separate methods.

            They improve readability by keeping the logic close to where it is used.

            They also make the code more flexible, since behavior can be passed as a parameter easily.

            Lambda expressions are widely used with delegates, LINQ, and generic methods,
            which makes them very powerful for filtering, sorting, and transforming data.
            */

            #endregion


            #region Q20

            double x = 10.0;
            double y = 2.0;


            // division using lambda expression
            double divisionResult = PerformDoubleOperation(x, y, (a, b) => a / b);

            Console.WriteLine("Division Result:");
            Console.WriteLine($"{x} / {y} = {divisionResult}");


            // exponentiation using lambda expression
            double powerResult = PerformDoubleOperation(x, y, (a, b) => Math.Pow(a, b));

            Console.WriteLine("\nExponentiation Result:");
            Console.WriteLine($"{x} ^ {y} = {powerResult}");



            /*
            Question Answer:

            Lambda expressions enhance expressiveness because they allow mathematical logic
            to be written directly where it is needed in a simple and compact way.

            Instead of creating separate methods for each operation like division or exponentiation,
            we can define the operation inline using a lambda expression.

            This makes the code easier to read and understand, especially for short mathematical operations.

            It also improves flexibility, because we can easily change the operation without modifying
            the main function, which makes the code more reusable and maintainable.
            */

            #endregion


        }





        static void PrintEmployees(Employee[] employees)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine($"Name: {employees[i].Name}, Salary: {employees[i].Salary}");
            }
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static T GetDefault<T>()
        {
            return default(T);
        }

        #region for Q11
        // delegate declaration
        delegate string StringTransformer(string input);


        // method to apply transformation to list
        static List<string> ApplyTransformation(List<string> list, StringTransformer transformer)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                result.Add(transformer(list[i]));
            }

            return result;
        }


        // uppercase method
        static string ToUpperCase(string input)
        {
            return input.ToUpper();
        }


        // reverse method
        static string ReverseString(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
        #endregion

        #region for Q12
        // delegate declaration
        delegate int MathOperation(int a, int b);


        // function that uses delegate
        static int PerformOperation(int a, int b, MathOperation operation)
        {
            return operation(a, b);
        }


        // operation methods
        static int Add(int a, int b)
        {
            return a + b;
        }

        static int Subtract(int a, int b)
        {
            return a - b;
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static int Divide(int a, int b)
        {
            return a / b;
        }
        #endregion


        #region for Q13
        // generic delegate declaration
        delegate R Transformer<T, R>(T input);


        // generic transformation method
        static List<R> TransformList<T, R>(List<T> list, Transformer<T, R> transformer)
        {
            List<R> result = new List<R>();

            for (int i = 0; i < list.Count; i++)
            {
                result.Add(transformer(list[i]));
            }

            return result;
        }


        // sample transformation methods
        static string ConvertIntToString(int number)
        {
            return number.ToString();
        }

        static int SquareNumber(int number)
        {
            return number * number;
        }
        #endregion


        #region for Q14
        static List<TResult> ApplyFunc<T, TResult>(List<T> list, Func<T, TResult> func)
        {
            List<TResult> result = new List<TResult>();

            for (int i = 0; i < list.Count; i++)
            {
                result.Add(func(list[i]));
            }

            return result;
        }
        #endregion


        #region for Q15
        static void ApplyAction<T>(List<T> list, Action<T> action)
        {
            for (int i = 0; i < list.Count; i++)
            {
                action(list[i]);
            }
        }
        #endregion

        #region for Q16
        static List<T> FilterList<T>(List<T> list, Predicate<T> predicate)
        {
            List<T> result = new List<T>();

            for (int i = 0; i < list.Count; i++)
            {
                if (predicate(list[i]))
                {
                    result.Add(list[i]);
                }
            }

            return result;
        }
        #endregion




        #region for Q17

        static List<string> FilterStrings(List<string> list, Predicate<string> condition)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                if (condition(list[i]))
                {
                    result.Add(list[i]);
                }
            }

            return result;
        }

        #endregion



        #region for Q18

        static int PerformMathOperation(int a, int b, MathOperation operation)
        {
            return operation(a, b);
        }
        #endregion

        #region for Q20
        delegate double DoubleOperation(double a, double b);

        static double PerformDoubleOperation(double a, double b, DoubleOperation operation)
        {
            return operation(a, b);
        }
        #endregion 



    }
}
