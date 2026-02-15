using System;

namespace day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region q1
            Car c1 = new Car();
            Car c2 = new Car(1);
            Car c3 = new Car(2, "Toyota");
            Car c4 = new Car(3, "BMW", 50000);

            c1.Display();
            c2.Display();
            c3.Display();
            c4.Display();

            /*
            Question Answer:
            When you define any constructor in C#, the compiler stops creating the default constructor automatically.
            So if you still want a default constructor, you must write it yourself.
            */

            #endregion

            #region q2
            Calculator calc = new Calculator();

            int result1 = calc.Sum(5, 10);
            int result2 = calc.Sum(1, 2, 3);
            double result3 = calc.Sum(2.5, 3.7);

            Console.WriteLine("Sum of 2 integers: " + result1);
            Console.WriteLine("Sum of 3 integers: " + result2);
            Console.WriteLine("Sum of 2 doubles: " + result3);
            /*
            Question Answer:
            Method overloading improves readability because we use the same method name (Sum) for similar operations.
            It improves reusability because we do not need to create different method names like Sum2, Sum3, SumDouble.
            This makes the code cleaner and easier to understand and use.
            */
            #endregion

            #region q3
            Child c = new Child(10, 20, 30);
            c.Display();
            /*
            Question Answer:
            Constructor chaining is used to call the base class constructor from the child class.
            This ensures that the base class properties are properly initialized before the child class adds its own initialization.
            */
            #endregion





        }
    }
}
